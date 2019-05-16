using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.Security
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SignedUpAt { get; set; }
    }
}
