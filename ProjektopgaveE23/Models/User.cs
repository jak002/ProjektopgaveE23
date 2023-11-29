using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjektopgaveE23.Models
{
    public enum MembershipType { Junior=1, Senior=2, Familie=3}

    public class User
    {
        //[Required(ErrorMessage = "Udfyld dit brugernavn"), DisplayName("Brugernavn")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Udfyld dit password") DisplayName, Password")]
        public string Password { get; set; }

        //[DisplayName("Navn")]
        public string Name { get; set; }

        //[DisplayName("E-mail")]
        public string Email { get; set; }

        //[DisplayName("Telefon nummer")]
        public string PhoneNumber { get; set; }

        public bool Admin { get; set; }

        //[DisplayName("Medlemsskab")]
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
