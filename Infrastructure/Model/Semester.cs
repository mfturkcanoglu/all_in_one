using Infrastructure.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;

public class Semester : BaseModel
{
    [Required]
    [Column(name: "semester_name")]
    public string SemesterName { get; set; }

    [Required]
    [Column(name: "semester_beginning_date")]
    public DateTime SemesterBeginningDate { get; set; }

    [Required]
    [Column(name: "semester_end_date")]
    public DateTime SemesterEndDate { get; set; }
}