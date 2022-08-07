using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HikingGear.Models;
using System.Collections.Generic;
using System.Linq;

namespace HikingGear.Controllers 
{
  public class CategoriesController : Controller
  {
    private readonly HikingGearContext _db;

    public CategoriesController(HikingGearContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}