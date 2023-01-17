using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clickatell.OneApi.Sdk.Models.Responses
{
    public class MessageStatusApiResponse : ApiResponse
    {
        [JsonProperty("sms")]
        public MessageStatusEntry Sms { get; }
        [JsonProperty("whatsapp")]
        public MessageStatusEntry WhatsApp { get; }
    }


    public class MediaUploadApiResponse : ApiResponse
    {
        [JsonProperty("fileId")]
        public string FileId { get; }
        [JsonProperty("accepted")]
        public bool Accepted { get; }
    }

    public class MediaFileMetadataResponse : ApiResponse
    {
        [JsonProperty("expirationTime")]
        public long ExpirationTime { get; }
        [JsonProperty("broadcastAllowed")]
        public bool BroadcastAllowed { get; }
    }

    public abstract class ApiResponse
    {
        [JsonProperty("error")]
        public ResponseError Error { get; set; }        
        public bool Successful { get; set; }
    }

    public class MessagesResponse : ApiResponse
    {
        [JsonProperty("messages")]
        public IReadOnlyList<Message> Messages { get; }

        public class Message
        {
            [JsonProperty("error")]
            public ResponseError Error { get; set; }
            [JsonProperty("apiMessageId")]
            public string ApiMessageId { get; set; }
            [JsonProperty("accepted")]
            public bool Accepted { get; set; }
            [JsonProperty("to")]
            public string To { get; set; }
            [JsonProperty("clientMessageId")]
            public string ClientMessageId { get; set; }
        }
    }
}
