using ProjektopgaveE23.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ProjektopgaveE23.Models
{
    public class Event
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Indtast navn på begivenhed")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Krav om dato")]
        [CustomDate(ErrorMessage ="Dato skal være indenfor range")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage ="Indtast afholdelsessted")]
        public string? Place { get; set; }

        public int? Attendees { get; set; }

        [Required(ErrorMessage ="Indtast beskrivelse")]
        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? Author { get; set; }



        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else if (!(obj is Event)) return false;

            else if (((Event)obj).Id == this.Id) return true;

            return false;
        }


    }
}
