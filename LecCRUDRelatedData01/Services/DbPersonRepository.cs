using LecCRUDRelatedData01.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LecCRUDRelatedData01.Services;

public class DbPersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _db;

    public DbPersonRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public Recommendation CreateRecommendation(int personId, Recommendation recommendaton)
    {
        var person = Read(personId);
        if (person != null)
        {
            person.Recommendations.Add(recommendaton);
            recommendaton.Person = person;
            _db.SaveChanges();
        }
        return recommendaton;
    }

    public Person? Read(int id)
    {
        //var person = _db.People.Find(id);
        //if (person != null)
        //{
        //    _db.Entry(person)
        //        .Collection(p => p.Recommendations)
        //        .Load();
        //}

        //return person;

        return _db.People
            .Include(p => p.Recommendations)
            .FirstOrDefault(p => p.Id == id);
    }

    public ICollection<Person> ReadAll()
    {
        return _db.People
            .Include(p => p.Recommendations)
            .ToList();
    }

    public void UpdateRecommendation(int personId, Recommendation recommendation)
    {
        var person = Read(personId);
        if(person != null)
        {
            var recommendationToUpdate = person.Recommendations
                .FirstOrDefault(r => r.Id == recommendation.Id);
            if(recommendationToUpdate != null)
            {
                recommendationToUpdate.Narrative = recommendation.Narrative;
                recommendationToUpdate.Rating = recommendation.Rating;
                _db.SaveChanges();
            }
        }
    }

    public void DeleteRecommendation(int personId, int recommendationId)
    {
        var person = Read(personId);
        if(person != null)
        {
            var recommendation = person.Recommendations
               .FirstOrDefault(r => r.Id == recommendationId);
            if(recommendation != null)
            {
                person.Recommendations.Remove(recommendation);
                _db.SaveChanges();
            }
        }
    }
}

