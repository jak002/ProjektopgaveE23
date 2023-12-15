using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;
using System.Collections.Generic;
using System.Text.Json;

namespace ProjektopgaveE23.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private IBoatRepository _repo;

        private IUserRepository _userRepository;

        public List<Boat> Boats { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public User CurrentUser { get; set; }
        public string ErrorMessage { get; set; }


        public IndexModel(IBoatRepository boatRepository, IUserRepository userRepository)
        {
            _repo = boatRepository;
            _userRepository = userRepository;
        }

        public void OnGet()
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername != null)
            {
                CurrentUser = _userRepository.GetUser(sessionusername);
            }
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = _repo.FilterBoats(FilterCriteria);
            }
            else
            {
                try
                {
                    Boats = _repo.GetAllBoats();
                }
                catch (FileNotFoundException ex)
                {
                    ErrorMessage = "Filen blev ikke fundet " + ex.Message;
                    Boats = new List<Boat>();
                }
                catch (JsonException ex)
                {
                    ErrorMessage = "Filen er ikke korrekt format " + ex.Message;
                    Boats = new List<Boat>();
                }
                catch (IOException ex)
                {
                    ErrorMessage = "Fejl: - " + ex.Message;
                    Boats = new List<Boat>();
                }
                catch (Exception ex)
                {
                    ErrorMessage = "Fejl: - " + ex.Message;
                    Boats = new List<Boat>();
                }
                
            }
            
        }
    }
}
