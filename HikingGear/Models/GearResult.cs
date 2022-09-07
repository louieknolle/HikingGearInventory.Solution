using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HikingGear.Models
{
  public class GearResult
  {
    public int GearId { get; set; }
    public string Family { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Price { get; set; }  

    public static List<GearResult> GetGearResultss()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<GearResult> gearResultList = JsonConvert.DeserializeObject<List<GearResult>>(jsonResponse.ToString());

      return gearResultList;
    }
  }
}