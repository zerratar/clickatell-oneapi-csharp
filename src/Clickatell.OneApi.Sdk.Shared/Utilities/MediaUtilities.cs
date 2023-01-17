using Clickatell.OneApi.Sdk.Models;
using System;
using System.Collections.Generic;

namespace Clickatell.OneApi.Sdk.Utilities
{
    public static class MediaUtilities
    {
        private static readonly List<MediaContentType> contentTypes;
        static MediaUtilities()
        {
            contentTypes = new List<MediaContentType>
            {
                new MediaContentType(MediaType.Audio, new[] {"audio/acc", "audio/mp4", "audio/amr", "audio/mpeg", "audio/ogg"}, new string[0], 16,20,30),
                new MediaContentType(MediaType.Document, new[] {"application/pdf", "application/msword", "application/vnd.ms-powerpoint", "application/vnd.ms-excel", "text/plain"}, new []{"application/pdf"}, 100,20,30),
                new MediaContentType(MediaType.Image, new[] {"image/jpeg", "image/png"}, new[] {"image/jpeg", "image/png"}, 5,20,30),
                new MediaContentType(MediaType.Video, new[] {"video/mp4", "video/3gpp"}, new[] {"video/mp4", "video/3gpp"}, 5,20,30),
            };
        }

        public static IReadOnlyList<MediaContentType> GetSupportedMediaContent()
        {
            return contentTypes;
        }

        public static bool IsSupported(string mimeType)
        {
            foreach (var item in contentTypes)
            {
                foreach (var mt in item.SupportedMessageMimeTypes)
                {
                    if (mt.Equals(mimeType, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

                foreach (var mt in item.SupportedTemplateMimeTypes)
                {
                    if (mt.Equals(mimeType, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static string GetMimeType(string fileName)
        {
            var ext = System.IO.Path.GetExtension(fileName).ToLower();
            switch (ext)
            {
                // audio
                case ".acc": return "audio/acc";
                //case ".mp4": return "audio/mp4";
                case ".amr": return "audio/amr";
                case ".mpeg": return "audio/mpeg";
                case ".ogg": return "audio/ogg";

                // document
                case ".pdf": return "application/pdf";
                case ".doc":
                case ".docx": return "application/msword";
                case ".ppt": return "application/vnd.ms-powerpoint";
                case ".xlsx":
                case ".xls": return "application/vnd.ms-excel";
                case ".txt": return "text/plain";

                // images
                case ".jpeg":
                case ".jpg": return "image/jpeg";
                case ".png": return "image/png";

                // videos
                case ".mp4": return "video/mp4";
                case ".3gp": return "video/3gpp";
            }
            return ext;
        }
    }
}
