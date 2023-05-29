using Infrastructure.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;

[Table(name: "course_student")]
public class CourseStudent : BaseModel
{
    [Required]
    [Column(name: "student_id")]
    public string StudentId { get; set; }
    public virtual User Student { get; set; }

    [Required]
    [Column(name: "course_id")]
    public Guid CourseId { get; set; }
    public virtual Course Lesson { get; set; }
}