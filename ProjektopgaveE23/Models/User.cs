﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjektopgaveE23.Models
{
    public enum MembershipType { Junior=1, Senior=2, Familie=3}

    public class User
    {
        [Display(Name = "Brugernavn")]
        [Required(ErrorMessage = "Udfyld dit brugernavn")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Udfyld dit password")]
        public string Password { get; set; }

        [Display(Name = "Navn")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Telefon nummer")]
        public string PhoneNumber { get; set; }

        public bool Admin { get; set; }

        [Display(Name = "Medlemsskab")]
        public MembershipType MembershipType { get; set; }

        public User()
        {
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is User)
                {
                    if (((User)obj).Username == this.Username) return true; else return false;
                } else return false;
            }
            else return false;
        } 
    }
}
