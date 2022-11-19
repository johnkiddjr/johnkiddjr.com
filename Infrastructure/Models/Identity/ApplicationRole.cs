using System;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Models.Identity
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationRole : IdentityRole<Guid>
    {
    }
}