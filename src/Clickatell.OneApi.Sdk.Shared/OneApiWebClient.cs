using Clickatell.OneApi.Sdk.Models;
using Clickatell.OneApi.Sdk.Models.Requests;
using Clickatell.OneApi.Sdk.Models.Responses;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;

namespace Clickatell.OneApi.Sdk
{
    public class OneApiWebClient : IOneApiClient
    {
        private HttpClient http;
        private bool disposed;

        public OneApiWebClient(string baseUrl, Credentials credentials)
        {
            this.Credentials = credentials;
            this.BaseUrl = baseUrl;

            http = new HttpClient();
            http.BaseAddress = new Uri(GetBaseUrl());
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", this.Credentials.AuthToken);
        }

        public OneApiWebClient(string baseUrl, string authToken)
            : this(baseUrl, new Credentials { AuthToken = authToken })
        {
        }

        public OneApiWebClient(IOneApiClientSettings settings)
            : this(settings.BaseUrl, settings.Credentials)
        {
        }

        public Credentials Credentials { get; set; }
        public string BaseUrl { get; set; }

        public async Task<MessagesResponse> SendMessageAsync(IRecipent recipent, IContent content, Channels channels)
        {
            try
            {
                var requestContent = BuildHttpContent(recipent, content, channels);
                return await SendRequestAsync<MessagesResponse>("message", requestContent);
            }
            catch (System.Exception exc)
            {
                return new MessagesResponse
                {
                    Error = new ResponseError
                    {
                        ErrorMessage = exc.ToString(),
                    }
                };
            }
        }

        private async Task<T> SendRequestAsync<T>(string path, HttpContent requestContent)
            where T : ApiResponse
        {
            using (var response = requestContent is JsonContent json
                ? await http.PostAsJsonAsync(path, json.Value)
                : await http.PostAsync(path, requestContent))
            {
                var statusCode = (int)response.StatusCode;
                var resultString = await response.Content.ReadAsStringAsync();
                var responseObj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(resultString);
                // let this throw.
                responseObj.Successful = responseObj.Error == null || responseObj.Error.Code <= 0;
                return responseObj;
            }
        }

        private string GetBaseUrl()
        {
            if (!BaseUrl.EndsWith("/"))
                BaseUrl += "/";
            return BaseUrl;
        }

        private string GetApiPath(string method, params string[] args)
        {
            return method + (args != null && args.Length > 0 ? "/" + string.Join("/", args) : string.Empty);
        }

        private HttpContent BuildHttpContent(IRecipent recipent, IContent content, Channels channels)
        {
            var sendSms = (channels & Channels.Sms) != 0;
            var useWhatsApp = (channels & Channels.Whatsapp) != 0;

            var req = new TextMessageRequest();
            req.Messages = new List<TextMessageRequest.TextMessage>();

            if (content is ITextContent textContent)
            {
                if (sendSms)
                {
                    req.Messages.Add(new TextMessageRequest.TextMessage
                    {
                        Channel = "sms",
                        Content = textContent.Content,
                        To = recipent.To,
                    });
                }

                if (useWhatsApp)
                {
                    req.Messages.Add(new TextMessageRequest.TextMessage
                    {
                        Channel = "whatsapp",
                        Content = textContent.Content,
                        To = recipent.To,
                    });
                }
            }

            if (content is IBinaryContent binaryContent)
            {
                // not supported yet.
            }

            return JsonContent.Create(req);
        }

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
            try
            {
                if (http != null)
                {
                    http.Dispose();
                }
            }
            catch { }
        }

        public class TextMessageRequest
        {
            [Newtonsoft.Json.JsonProperty("messages"), JsonPropertyName("messages")]
            public List<TextMessage> Messages { get; set; }

            public class TextMessage
            {
                [Newtonsoft.Json.JsonProperty("channel"), JsonPropertyName("channel")]
                public string Channel { get; set; }

                [Newtonsoft.Json.JsonProperty("to"), JsonPropertyName("to")]
                public string To { get; set; }

                [Newtonsoft.Json.JsonProperty("content"), JsonPropertyName("content")]
                public string Content { get; set; }
            }
        }
    }
}
