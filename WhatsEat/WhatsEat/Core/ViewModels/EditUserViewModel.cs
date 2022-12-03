using WhatsEat.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WhatsEat.Core.ViewModels
{
    public class EditUserViewModel
    {
#pragma warning disable CS8618 // Non-nullable property 'User' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public ApplicationUser User { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'User' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'Roles' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public IList<SelectListItem> Roles { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Roles' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
