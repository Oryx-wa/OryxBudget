using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OryxBudgetWeb.Models
{
  public class OperatorsClient
  {
    private string _operatorUrl = "http://localhost:5502/api/Operator";

    //DropDown

    public IEnumerable<OperatorClientModel> GetOperatorsList()
    {

      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri(_operatorUrl);
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
