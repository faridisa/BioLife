using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BioLife.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? VerificationCode { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? VerificationCodeExpiry { get; set; }
    }
    public class AppRole : IdentityRole
    {
        public AppRole()
        {
        }

        public AppRole(string roleName) : base(roleName)
        {
        }
    }
}
