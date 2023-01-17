using Clickatell.OneApi.Sdk.Models;
using Clickatell.OneApi.Sdk.Models.Requests;
using Clickatell.OneApi.Sdk.Models.Responses;
using System.Threading.Tasks;

namespace Clickatell.OneApi.Sdk
{
    public interface IOneApiClient : IDisposable
    {
        Task<MessagesResponse> SendMessageAsync(IRecipent recipent, IContent content, Channels channels = Channels.All);
        //Task<ApiResponse> DownloadMediaAsync(IMediaRequest )
    }
}
