using LecCRUDRelatedData01.Services;
using Microsoft.AspNetCore.Mvc;

namespace LecCRUDRelatedData01.Controllers;

public class PersonController : Controller
{
    private readonly IPersonRepository _personRepo;

    public PersonController(IPersonRepository personRepo)
    {
        _personRepo = personRepo;
    }

    public IActionResult Index()
    {
        var peopleModel = _personRepo.ReadAll();
        return View(peopleModel);
    }

    public IActionResult Details(int id)
    {
        var person = _personRepo.Read(id);
        return View(person);
    }
}

