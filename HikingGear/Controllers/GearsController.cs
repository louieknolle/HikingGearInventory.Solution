using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HikingGear.Models;
using System.Collections.Generic;
using System.Linq;

namespace HikingGear.Controllers
{
  public class GearsController : Controller
  {
    private readonly HikingGearContext _db;

    public GearsController(HikingGearContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Gears.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Gear gear, int CategoryId)
    {
      _db.Gears.Add(gear);
      _db.SaveChanges();
      if (CategoryId != 0)
      {
        _db.CategoryGear.Add(new CategoryGear() { CategoryId = CategoryId, GearId = gear.GearId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index", "Categories", null);
      
    }

    public ActionResult Details(int id)
    {
      var thisGear = _db.Gears
          .Include(gear => gear.JoinEntities)
          .ThenInclude(join => join.Category)
          .FirstOrDefault(gear => gear.GearId == id);
      return View(thisGear);
    }

    public ActionResult Edit(int id)
    {
      var thisGear = _db.Gears.FirstOrDefault(gear => gear.GearId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(thisGear);
    }

    [HttpPost]
    public ActionResult Edit(Gear gear, int CategoryId)
    {
      if (CategoryId != 0)
      {
        _db.CategoryGear.Add(new CategoryGear() { CategoryId = CategoryId, GearId = gear.GearId });
      }
      _db.Entry(gear).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCategory(int id)
    {
      var thisGear = _db.Gears.FirstOrDefault(gear => gear.GearId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(thisGear);
    }

    [HttpPost]
    public ActionResult AddCategory(Gear gear, int CategoryId)
    {
      if (CategoryId != 0)
      {
        _db.CategoryGear.Add(new CategoryGear() { CategoryId = CategoryId, GearId = gear.GearId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisGear = _db.Gears.FirstOrDefault(gear => gear.GearId == id);
      return View(thisGear);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisGear = _db.Gears.FirstOrDefault(gear => gear.GearId == id);
      _db.Gears.Remove(thisGear);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteCategory(int joinId)
    {
      var joinEntry = _db.CategoryGear.FirstOrDefault(entry => entry.CategoryGearId == joinId);
      _db.CategoryGear.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
