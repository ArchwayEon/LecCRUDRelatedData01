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

    public IActionResult Edit([Bind(Prefix = "id")] int personId, int recId)
    {
        var person = _personRepo.Read(personId);
        if (person == null)
        {
            return RedirectToAction("Index", "Person");
        }
        var recommendation = person.Recommendations.FirstOrDefault(r => r.Id == recId);
        if (recommendation == null)
        {
            return RedirectToAction("Details", "Person", new { id = personId });
        }
        ViewData["Person"] = person;
        return View(recommendation);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Edit(int personId, Recommendation recommendation)
    {
        if (ModelState.IsValid)
        {
            _personRepo.UpdateRecommendation(personId, recommendation);
            return RedirectToAction("Details", "Person", new { id = personId });
        }
        ViewData["Person"] = _personRepo.Read(personId);
        return View(recommendation);
    }



}

