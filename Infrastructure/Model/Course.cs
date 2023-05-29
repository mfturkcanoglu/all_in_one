using Infrastructure.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model;

[Table(name: "course")]
public class Course : BaseModel
{
    [Column(name: "lecturer_id")]
    [Required]
    public string LecturerId { get; set; }

    [Required]
    public virtual User Lecturer { get; set; }

    [Column(name: "semester_id")]
    [Required]
    public Guid SemesterId { get; set; }

    [Required]
    public Semester Semester { get; set; }

    [Column(name: "course_name")]
    [Required]
    public string CourseName { get; set; }

    [Column(name: "course_code")]
    [Required]
    public string CourseCode { get; set; }
    public virtual IList<CourseStudent> CourseStudents { get; set; }
}