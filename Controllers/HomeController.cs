using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using newWebAppA00272195.Models;

namespace newWebAppA00272195.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Index()
    {
        Book record = new Book();

     // Get list of Book catalogue
       record.BookList = Book.GetAll().ToList();
       
        return View(record);
    }


    [HttpPost]
    public ActionResult Create(Book model)
    {
     if (!ModelState.IsValid)
     {
       return RedirectToAction("Index");
     }
      // create a new book catalogue
       Book.CreateBook(model);
       return RedirectToAction("Index");
    }


    [HttpPost("/index/delete")]
    public ActionResult DeleteAll()
    {
      // Bonus feature to Clear all book item
      Book.ClearAll();
      return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
