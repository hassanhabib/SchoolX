
using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using SchoolX.Api;
using System.Net.Http;

namespace SchoolX.Tests.Acceptance.Brokers
{
    public partial class SchoolXApiBroker
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private readonly HttpClient baseClient;
        private readonly IRESTFulApiFactoryClient apiFactoryClient;

        public SchoolXApiBroker()
        {
            this.webApplicationFactory = new WebApplicationFactory<Startup>();
            this.baseClient = this.webApplicationFactory.CreateClient();
            this.apiFactoryClient = new RESTFulApiFactoryClient(this.baseClient);
        }
    }
}
