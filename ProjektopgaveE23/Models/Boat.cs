using System.ComponentModel.DataAnnotations;

namespace ProjektopgaveE23.Models
{
    public class Boat
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of boat is required"), MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Boat()
        {
            
        }
    }
}
