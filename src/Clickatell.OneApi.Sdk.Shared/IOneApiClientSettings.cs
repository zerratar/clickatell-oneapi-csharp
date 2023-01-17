using Clickatell.OneApi.Sdk.Models;

namespace Clickatell.OneApi.Sdk
{
    public interface IOneApiClientSettings
    {
        string BaseUrl { get; }
        Credentials Credentials { get; }
    }

    public class DeveloperEndpointClientSettings : IOneApiClientSettings
    {
        public DeveloperEndpointClientSettings(string authToken)
        {
            Credentials = new Credentials(authToken);
        }

        public string BaseUrl => "https://platform.clickatell.com/v1/";//"https://dev-platform.clickatelllabs.com/v1/";

        public Credentials Credentials { get; }
    }

    public class ProductionEndpointClientSettings : IOneApiClientSettings
    {
        public ProductionEndpointClientSettings(string authToken)
        {
            Credentials = new Credentials(authToken);
        }

#warning Endpoint has not been set to Production Endpoint!!
        public string BaseUrl => "https://platform.clickatell.com/v1/";//"https://dev-platform.clickatelllabs.com/v1/";

        public Credentials Credentials { get; }
    }
}
