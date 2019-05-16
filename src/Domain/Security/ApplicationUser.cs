using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.Security
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime SignedUpAt { get; set; }
    }
}
