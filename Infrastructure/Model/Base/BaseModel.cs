using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model.Base;

public class BaseModel
{
    [Column(name: "id")]
    [Required]
    public Guid Id { get; set; }

    [Column(name: "created")]
    [Required]
    public DateTime Created { get; set; }

    [Column(name: "last_updated")]
    [Required]
    public DateTime LastUpdated { get; set; }

    [Column(name: "deleted")]
    public DateTime? Deleted { get; set; }
}