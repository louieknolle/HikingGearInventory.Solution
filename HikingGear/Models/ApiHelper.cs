using System.Threading.Tasks;
using RestSharp;

namespace HikingGear.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"gears", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"gears/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    //don't think I'll actually need this except for maybe admin role
    public static async Task Post(string newGearResult)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"gears", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newGearResult);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newGearResult)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"gears/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newGearResult);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5003/api");
      RestRequest request = new RestRequest($"gears/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}