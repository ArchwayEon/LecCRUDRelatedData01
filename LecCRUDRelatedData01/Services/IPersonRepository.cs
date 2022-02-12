using LecCRUDRelatedData01.Models.Entities;

namespace LecCRUDRelatedData01.Services;

public interface IPersonRepository
{
    Person? Read(int id);
    ICollection<Person> ReadAll();
    Recommendation CreateRecommendation(int personId, Recommendation recommendaton);
}

