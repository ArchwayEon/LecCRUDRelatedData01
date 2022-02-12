using System.ComponentModel.DataAnnotations;

namespace LecCRUDRelatedData01.Models.Entities;

public class Person
{
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string UserName { get; set; } = String.Empty;

    [StringLength(256)]
    public string? FirstName { get; set; }

    [StringLength(256)]
    public string? MiddleName { get; set; }

    [Required]
    [StringLength(256)]
    public string LastName { get; set; } = String.Empty;

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public ICollection<Recommendation> Recommendations { get; set; }
        = new List<Recommendation>();
}

