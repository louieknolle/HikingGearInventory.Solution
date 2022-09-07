using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HikingGear.Models
{
  public class GearResult
  {
    public int GearResultId { get; set; }
    public string Family { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Price { get; set; }  

    public static List<GearResult> GetGearResults()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<GearResult> gearResultList = JsonConvert.DeserializeObject<List<GearResult>>(jsonResponse.ToString());

      return gearResultList;
    }

    public static GearResult GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      GearResult gearResult = JsonConvert.DeserializeObject<GearResult>(jsonResponse.ToString());

      return gearResult;
    }

    public static void Post(GearResult gearResult)
    {
      string jsonGearResult = JsonConvert.SerializeObject(gearResult);
      var apiCallTask = ApiHelper.Post(jsonGearResult);
    }

    public static void Put(GearResult gearResult)
    {
      string jsonGearResult = JsonConvert.SerializeObject(gearResult);
      var apiCallTask = ApiHelper.Put(gearResult.GearResultId, jsonGearResult);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}