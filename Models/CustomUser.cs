using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Models
{
    public class CustomUser
    {
        [Key]
        public Guid Id { get; set; }
      
        [StringLength(256)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        List<CustomUserClaim> CustomUserClaims { get; set; } = new List<CustomUserClaim>();
    }
}
