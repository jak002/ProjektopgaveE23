using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using System.Text.Json;

namespace ProjektopgaveE23.Pages.Events
{
    public class IndexModel : PageModel
    {

        private IEventRepository _repo;
        private IUserRepository _userRepository;

        public List<Event> Events { get; set; }

        public User CurrentUser { get; set; }

        public string ErrorMessage { get; set; }

        public IndexModel(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _repo = eventRepository;
            _userRepository = userRepository;
        }



        public void OnGet()
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername != null)
            {
                CurrentUser = _userRepository.GetUser(sessionusername);
            }

            try
            {
                Events = _repo.GetAllEvents();
            }
            catch (FileNotFoundException ex)
            {
                ErrorMessage = "Fejl: filen blev ikke fundet - "+ex.Message;
                Events= new List<Event>();
            }
            catch (JsonException ex)
            {
                ErrorMessage = "Fejl: filen er ikke i korrekt format - " + ex.Message;
                Events= new List<Event>();
            }
            catch (IOException ex)
            {
                ErrorMessage = "Fejl: - " + ex.Message;
                Events = new List<Event>();
            }
            catch (Exception ex)
            {
                ErrorMessage = "Fejl: - " + ex.Message;
                Events = new List<Event>();
            }



        }





    }
}
