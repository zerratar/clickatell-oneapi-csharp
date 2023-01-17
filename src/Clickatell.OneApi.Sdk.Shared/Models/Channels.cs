using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clickatell.OneApi.Sdk.Models
{
    [Flags]
    public enum Channels
    {
        Whatsapp = 1,
        Sms = 2,
        All = Whatsapp | Sms,
    }

    public class Credentials
    {
        public Credentials() { }
        public Credentials(string authToken)
        {
            AuthToken = authToken;
        }

        public string AuthToken { get; set; }
    }

    public class MessageStatusEntry
    {
        public MessageStatus Status { get; set; }
        public long Timestamp { get; set; }
    }

    public enum MessageStatus
    {
        UNKNOWN,
        QUEUED,
        SCHEDULED,
        SENT_TO_SUPPLIER,
        DEVICE_ACK,
        READ,
        EXPIRED,
        STOPPED_BY_USER,
        STOPPED_BY_ADMIN,
        DELIVERY_FAILURE,
        EMULATED,
        INSUFFICIENT_ACCOUNT_BALANCE,
        VOLUME_LIMIT,
        VOLUME_LIMIT_DAILY,
        VOLUME_LIMIT_MONTHLY,
        RECIPIENT_DOES_NOT_EXIST,
        ENCRYPTION_ACCESS_DENIED,
        ENCRYPTION_CONTENT_ERROR,
        MEDIA_NOT_FOUND,
        MEDIA_SIZE_ERROR,
        MEDIA_CHECKSUM_FAILURE,
        MEDIA_REJECTED_BY_SUPPLIER,
        MEDIA_METADATA_ERROR,
        ROUTING_ERROR,
        WHATSAPP_ACCOUNT_PAYMENT_ISSUE,
        WHATSAPP_RE_ENGAGEMENT_REQUIRED,
        WHATSAPP_SPAM_RATE_LIMIT_REACHED,
        WHATSAPP_SERVER_RATE_LIMIT,
        WHATSAPP_HSM_NOT_AVAILABLE,
        WHATSAPP_HSM_PARAM_COUNT_MISMATCH,
        WHATSAPP_HSM_IS_MISSING,
        WHATSAPP_HSM_DOWNLOAD_FAILED,
        WHATSAPP_HSM_PACK_IS_MISSING,
        WHATSAPP_EXPERIMENTAL_NUMBER,
        WHATSAPP_TEMPLATE_TEXT_TOO_LONG,
        WHATSAPP_TEMPLATE_FORMAT_MISMATCH,
        WHATSAPP_TEMPLATE_FORMATTING_POLICY_VIOLATED,
        WHATSAPP_TEMPLATE_MEDIA_FORMAT_UNSUPPORTED,
        WHATSAPP_PARAMETER_MISSING,
        WHATSAPP_PARAMETER_INVALID,
        WHATSAPP_PARAMETER_NOT_REQUIRED,
        WHATSAPP_TEMPLATE_INVALID_URL,
        WHATSAPP_TEMPLATE_INVALID_PHONE_NUMBER,
        WHATSAPP_TEMPLATE_RECEIVER_NO_BUTTON_SUPPORT
    }


    public enum MediaType
    {
        Audio,
        Document,
        Image,
        Video
    }

    public class ResponseError
    {
        public ResponseError() { }
        public ResponseError(int code, int httpStatusCode, string errorMessage, bool globalLevel, bool messageLevel)
        {
            Code = code;
            HttpStatusCode = httpStatusCode;
            ErrorMessage = errorMessage;
            GlobalLevel = globalLevel;
            MessageLevel = messageLevel;
        }
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("httpStatusCode")]
        public int HttpStatusCode { get; set; }
       
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty("globalLevel")]
        public bool GlobalLevel { get; set; }
        [JsonProperty("messageLevel")]
        public bool MessageLevel { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class MediaContentType
    {
        // https://docs.clickatell.com/channels/one-api/supported-content-types/

        public MediaContentType(
            MediaType mediaType,
            IReadOnlyList<string> supportedMessageMimeTypes,
            IReadOnlyList<string> supportedTemplateMimeTypes,
            short whatsAppSizeLimit,
            short clickatellSizeLimit_InlineMedia,
            short clickatellSizeLimit_MediaUpload)
        {
            MediaType = mediaType;
            SupportedMessageMimeTypes = supportedMessageMimeTypes;
            SupportedTemplateMimeTypes = supportedTemplateMimeTypes;
            WhatsAppSizeLimitMegaBytes = whatsAppSizeLimit;
            ClickatellSizeLimitMegaBytes_InlineMedia = clickatellSizeLimit_InlineMedia;
            ClickatellSizeLimitMegaBytes_MediaUpload = clickatellSizeLimit_MediaUpload;
        }

        public MediaType MediaType { get; }
        public IReadOnlyList<string> SupportedMessageMimeTypes { get; }
        public IReadOnlyList<string> SupportedTemplateMimeTypes { get; }
        public short WhatsAppSizeLimitMegaBytes { get; }
        public short ClickatellSizeLimitMegaBytes_InlineMedia { get; }
        public short ClickatellSizeLimitMegaBytes_MediaUpload { get; }
    }

}
