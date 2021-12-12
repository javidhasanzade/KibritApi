using System;
using Microsoft.AspNetCore.Identity;

namespace KibritAPI.Models
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public string AppUserId { get; set; }
        public DateTime ExpiresAt { get; set; }
        public IdentityUser AppUser { get; set; }
    }
}