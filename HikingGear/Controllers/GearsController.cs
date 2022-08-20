using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HikingGear.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace HikingGear.Controllers
{
  [Authorize]
  public class GearsController : Controller
  {
    private readonly HikingGearContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public GearsController(UserManager<ApplicationUser> userManager, HikingGearContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        var userGears = _db.Gears.Where(entry => entry.User.Id == currentUser.Id).ToList();
        return View(userGears);
    }

    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Gear gear, int CategoryId)
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        gear.User = currentUser;
        _db.Gears.Add(gear);
        _db.SaveChanges();
        if (CategoryId != 0)
        {
            _db.CategoryGear.Add(new CategoryGear() { CategoryId = CategoryId, GearId = gear.GearId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
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
