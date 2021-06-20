using Microsoft.Extensions.Configuration;
using RESTFulSense.Clients;
using SchoolX.Api.Models.Configurations;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SchoolX.Api.Brokers.Apis
{
    public partial class SchoolEmApiBroker : ISchoolEmApiBroker
    {
        private readonly HttpClient httpClient;
        private readonly IRESTFulApiFactoryClient apiClient;

        public SchoolEmApiBroker(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.apiClient = GetApiClient(configuration);
        }

        private async ValueTask<T> GetAsync<T>(string relativeUrl) =>
            await this.apiClient.GetContentAsync<T>(relativeUrl);

        private IRESTFulApiFactoryClient GetApiClient(
             IConfiguration configuration)
        {
            LocalConfiguration localConfigurations =
                configuration.Get<LocalConfiguration>();

            string coreProfileBaseUrl =
                localConfigurations.SchoolEmApiUrl;

            this.httpClient.BaseAddress = new Uri(coreProfileBaseUrl);

            return new RESTFulApiFactoryClient(this.httpClient);
        }
    }
}
