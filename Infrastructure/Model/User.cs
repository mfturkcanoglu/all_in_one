using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Infrastructure.Model;

public class User : IdentityUser
{
    [JsonProperty(propertyName: "full_name")]
    public string FullName { get; set; }

    [JsonProperty(propertyName: "country_id")]
    public string CountryId { get; set; }

    [JsonProperty(propertyName: "photo")]
    public string Photo { get; set; } = string.Empty;

    [JsonProperty(propertyName: "active")]
    public bool Active { get; set; }

    [JsonProperty(propertyName: "user_role")]
    public UserRole UserRole { get; set; }

    [JsonIgnore]
    public virtual IList<CourseStudent> CourseStudents { get; set; }
}