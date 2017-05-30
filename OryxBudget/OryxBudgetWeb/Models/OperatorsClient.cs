using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OryxBudgetWeb.Models
{
    public class OperatorsClient
    {
        readonly ILogger<OperatorsClient> _logger;
        private string _apiUrl, _idSrv;
        private readonly OpOptions _options;
        //DropDown
        public OperatorsClient( ILogger<OperatorsClient> logger)
        {
            _apiUrl = "";// opOptions.ApiPath;
            _idSrv = ""; // opOptions.IdPath;
            _logger = logger;

            _logger.LogDebug(_apiUrl);
        }

        public async Task<IEnumerable<OperatorClientModel>> GetOperatorsList()
        {
            string action = "api/Operator";
            var discoveryClient = new DiscoveryClient(_idSrv);
            var doc =  await discoveryClient.GetAsync();
            var tclient = new TokenClient(
        doc.TokenEndpoint,
        "OryxBudgetClientCred",
        "F621F470-9731-4A25-80EF-67A6F7C5F4B8");
            var tresponse = await tclient.RequestClientCredentialsAsync("OryxBudget");
            var token = tresponse.AccessToken;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = client.GetAsync("Operator/Lookup").Result;
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string stringData = (response.Content.ReadAsStringAsync().Result);
            List<OperatorClientModel> data = JsonConvert.DeserializeObject<List<OperatorClientModel>>(stringData);
            return data;
        }
    }

    public interface IOperatosClient
    {
        Task<IEnumerable<OperatorClientModel>> GetOperatorsList();
    }

    

}
