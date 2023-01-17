using System;
using System.Collections.Generic;
using System.Text;
using Clickatell.OneApi.Sdk.Models;

namespace Clickatell.OneApi.Sdk.Utilities
{
    public static class ErrorCodes
    {
        private static readonly IReadOnlyDictionary<int, ResponseError> errors;
        static ErrorCodes()
        {
            // https://docs.clickatell.com/channels/one-api/one-api-errors-table/
            errors = new Dictionary<int, ResponseError> {
                { 1, new ResponseError(1, 401, "Invalid or missing integration API Key", true, false) },
                { 2, new ResponseError(2, 400, "Account is not active", true, false)},
                { 3, new ResponseError(3, 400, "Integration is not active", true, false)},
                { 7, new ResponseError(7, 401, "Originating IP address is not approved in your account", true, false)},
                { 18, new ResponseError(18, 500, "Internal error", true, true)},
                { 19, new ResponseError(19, 503, "Internal error, please retry", true, true)},
                { 20, new ResponseError(20, 402, "Insufficient account balance", false, true)},
                { 21, new ResponseError(21, 400, "Payload data is malformed", true, false)},
                { 22, new ResponseError(22, 400, "Maximum messages per request payload exceeded", true, false)},
                { 23, new ResponseError(23, 400, "Invalid or missing parameter: (parameter name)", false, true)},
                { 24, new ResponseError(24, 400, "Maximum message content size exceeded", false, true)},
                { 25, new ResponseError(25, 400, "Invalid recipient address: (MSISDN)", false, true)},
                { 26, new ResponseError(26, 400, "Recipient opted out", false, true)},
                { 27, new ResponseError(27, 400, "Recipient not available on channel", false, true)},
                { 28, new ResponseError(28, 400, "Recipient not available on sandbox", false, true)},
                { 29, new ResponseError(29, 0, "Reserved", false, false)},
                { 30, new ResponseError(30, 400, "Content type not supported", false, true)},
                { 31, new ResponseError(31, 400, "Media file size exceeds limit of xx MB", false, true)},
                { 32, new ResponseError(32, 400, "Media payload size exceeds limit of xx MB", false, true)},
                { 33, new ResponseError(33, 400, "Media item not found", false, true)},
                { 34, new ResponseError(34, 0, "Reserved", false, false)},
                { 35, new ResponseError(35, 0, "Reserved", false, false)},
                { 36, new ResponseError(36, 0, "Reserved", false, false)},
                { 37, new ResponseError(37, 0, "Reserved", false, false)},
                { 38, new ResponseError(38, 400, "Channel/feature is not active on integration", false, true)},
                { 39, new ResponseError(39, 400, "Channel is not available on integration", false, true)},
                { 40, new ResponseError(40, 400, "Character set is not supported: (charset)", false, true)},
                { 41, new ResponseError(41, 400, "Resource does not exist", true, false)},
                { 42, new ResponseError(42, 400, "HTTP method is not supported on this resource", true, false)},
                { 43, new ResponseError(43, 400, "Rate limit", true, true)},
                { 44, new ResponseError(44, 400, "FROM number is suspended", false, true)},
                { 45, new ResponseError(45, 400, "FROM number is not related to integration", false, true)},
                { 46, new ResponseError(46, 400, "Demo access has expired", false, true)},
                { 100, new ResponseError(100, 400, "Maximum message parts exceeded", false, true)},
                { 101, new ResponseError(101, 400, "Destination does not support two-way messaging", false, true)},
                { 110, new ResponseError(110, 400, "USA country limit: must use two-way integration", false, true)},
                { 111, new ResponseError(111, 400, "USA country limit: must enable STOP/SUBSCRIBE commands on integration", false, true) }
            };
        }

        public static ResponseError Get(int errorCode)
        {
            if (errors.TryGetValue(errorCode, out var error))
            {
                return error;
            }

            return default;
        }    
    }
}
