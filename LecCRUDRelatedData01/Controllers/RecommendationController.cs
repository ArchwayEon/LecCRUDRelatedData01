using LecCRUDRelatedData01.Models.Entities;
using LecCRUDRelatedData01.Services;
using Microsoft.AspNetCore.Mvc;

namespace LecCRUDRelatedData01.Controllers;

public class RecommendationController : Controller
{
    private readonly IPersonRepository _personRepo;

    public RecommendationController(IPersonRepository personRepo)
    {
        _personRepo = personRepo;
    }
    public IActionResult Create([Bind(Prefix = "id")] int personId)
    {
        var person = _personRepo.Read(personId);
        if (person == null)
        {
            return RedirectToAction("Index", "Person");
        }
        ViewData["Person"] = person;
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(int personId, Recommendation recommendation)
    {
        if (ModelState.IsValid)
        {
            recommendation.Id = 0;
            _personRepo.CreateRecommendation(personId, recommendation);
            return RedirectToAction("Index", "Person");
        }
        ViewData["Person"] = _personRepo.Read(personId);
        return View(recommendation);
    }

}

