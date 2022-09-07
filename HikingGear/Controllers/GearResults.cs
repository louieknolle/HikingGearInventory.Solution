using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HikingGear.Models;

namespace HikingGear.Controllers
{
  public class GearResultsController : Controller
  {
    public IActionResult Index()
    {
      var allGearResults = GearResult.GetGearResults();
      return View(allGearResults);
    }

    [HttpPost]
    public IActionResult Index(GearResult gearResult)
    {
      GearResult.Post(gearResult);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var gearResult = GearResult.GetDetails(id);
      return View(gearResult);
    }

    public IActionResult Edit(int id)
    {
      var gearResult = GearResult.GetDetails(id);
      return View(gearResult);
    }

    [HttpPost]
    public IActionResult Details(int id, GearResult gearResult)
    {
      gearResult.GearResultId = id;
      GearResult.Put(gearResult);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      GearResult.Delete(id);
      return RedirectToAction("Index");
    }
  }
}