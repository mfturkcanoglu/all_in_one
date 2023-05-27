namespace Infrastructure.Model.Base;

public class BaseModel
{
    public int Id { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    public DateTime? Deleted { get; set; }
}