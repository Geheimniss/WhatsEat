using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WhatsEat.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
#pragma warning disable CS8618 // Non-nullable property 'FirstName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    public string FirstName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'FirstName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'LastName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    public string LastName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'LastName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
}

public class ApplicationRole : IdentityRole
{

}
