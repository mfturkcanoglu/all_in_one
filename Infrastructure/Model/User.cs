﻿using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Model;

public class User : IdentityUser
{
    public string FullName { get; set; }
    public string CountryId { get; set; }
    public string Photo { get; set; }
    public bool Active { get; set; }
}