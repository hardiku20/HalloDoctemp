using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int CityId { get; set; }

    public int? Age { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNo { get; set; }

    public char? Gender { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public virtual City CityNavigation { get; set; } = null!;
}
