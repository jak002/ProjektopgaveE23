using System.ComponentModel.DataAnnotations;

namespace ProjektopgaveE23.Models
{
    public enum BoatType { TERA, FEVA, Laserjolle, Europajolle, Snipejolle, Wayfarer, Lynæs, Andet }
    public class Boat
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Navn på båd mangler"), MaxLength(30)]
        public string Name { get; set; }

        public string ?Description { get; set; }

        [Required(ErrorMessage = "Bådtype mangler")]
        public BoatType ?BoatModel { get; set; }

        
        public string ?BoatImage { get; set; }
        public Boat()
        {
            
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else if (!(obj is Boat)) return false;

            else if (((Boat)obj).Id == this.Id)
                return true;

            return false;
        }
    }
}
