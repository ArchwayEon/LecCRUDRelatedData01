using System.ComponentModel.DataAnnotations;

namespace LecCRUDRelatedData01.Models.Entities;

public class Recommendation
{
    public int Id { get; set; }

    public int Rating { get; set; }

    [StringLength(512)]
    public string Narrative { get; set; } = String.Empty;

    public int PersonId { get; set; }
    public Person? Person { get; set; }
}

