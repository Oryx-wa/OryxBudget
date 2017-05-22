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

namespace OryxBudgetWeb.Models
{
    public class OperatorsClient
    {
        private string _operatorUrl = "http://localhost:5502/api/Operator";

        //DropDown

        public async Task<IEnumerable<OperatorClientModel>> GetOperatorsList()
        {
            var discoveryClient = new DiscoveryClient("http://localhost:5000");
            var doc =  await discoveryClient.GetAsync();
            var tclient = new TokenClient(
        doc.TokenEndpoint,
        "OryxBudgetClientCred",
        "F621F470-9731-4A25-80EF-67A6F7C5F4B8");
            var tresponse = await tclient.RequestClientCredentialsAsync("OryxBudget");
            var token = tresponse.AccessToken;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_operatorUrl);
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
}
