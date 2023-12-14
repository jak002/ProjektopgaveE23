using System.ComponentModel.DataAnnotations;

namespace ProjektopgaveE23.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Udfyld titel")]
        public string? Title { get; set; }

        [Display(Name = "Brødtekst")]
        [Required(ErrorMessage ="Du skal tilføje tekst")]
        public string? Text { get; set; }

        //[Required(ErrorMessage = "Du skal tilføje et billede")]
        public string? BlogImage { get; set; }
        
        public DateTime Date { get; set; }

        public string? Author { get; set; }



        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else if (!(obj is Blog)) return false;

            else if (((Blog)obj).Id == this.Id)
                return true;

            return false;
        }

    }
}
