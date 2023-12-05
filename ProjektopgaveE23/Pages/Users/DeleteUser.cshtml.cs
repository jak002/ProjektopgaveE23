using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektopgaveE23.Models;
using ProjektopgaveE23.Interfaces;

namespace ProjektopgaveE23.Pages.Users
{
    /// <summary>
    /// This page fetches a single user, presents its general info, and updates the underlying repository with whether said user gets deleted or not.
    /// </summary>
    public class DeleteUserModel : PageModel
    {

        /// <summary>
        /// User repository is accessed through its interface, making it easier to implement a new system if we decide to change how we store users (for example, a database)
        /// </summary>
        private IUserRepository _urepo;
        /// <summary>
        /// The current user. Since this property isn't gonna be filled with information from the browser, BindProperty is not needed.
        /// </summary>
        public User UserToDelete { get; set; }
        /// <summary>
        /// Constructor, with user repository as a parameter.
        /// The local instance field for this kind of repository is assigned this parameter within the constructor.
        /// </summary>
        /// <param name="users">This will always receive the one user repository in use within the system, as it is added as a singleton.</param>
        public User CurrentUser { get; set; }
        public DeleteUserModel(IUserRepository users)
        {
            _urepo = users;
        }
        /// <summary>
        /// This method is called when this model's site is accessed, with a username as parameter.
        /// This username is used to locate a specific user object within the user repository, and assign it to the public property UserToDelete.
        /// </summary>
        /// <param name="username">This is received either from a link tied to a specific user, or from the session.</param>
        /// <returns>The same page.</returns>
        public IActionResult OnGet(string username)
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            if (sessionusername == null)
            {
                return RedirectToPage("Login");
            }
            else
            {
                CurrentUser = _urepo.GetUser(sessionusername);
                UserToDelete = _urepo.GetUser(username);
                return Page();
            }
        }

        /// <summary>
        /// This method is called when the "Delete" button is pressed, with a username as parameter.
        /// Since the user can't access this page without being logged in, their information can be fetched without a login check.
        /// The user repository's delete method is called, with the given username as argument.
        /// After this is done, the user is either returned to their info page, or, if the user has admin privileges and is accessing another user's info, the user index page.
        /// </summary>
        /// <param name="username">This is received from the user repository, given through the website's link.</param>
        /// <returns>A redirect to the user info page, or index page if criteria(admin + accessing another user) are met.</returns>
        public IActionResult OnPostDelete(string username)
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            CurrentUser = _urepo.GetUser(sessionusername);
            _urepo.DeleteUser(username);
            if (username != CurrentUser.Username && CurrentUser.Admin)
            {
                return RedirectToPage("Index");
            }
            return RedirectToPage("Info");
        }
        /// <summary>
        /// This method is called when the "Cancel" button is pressed.
        /// Since the user can't access this page without being logged in, their information can be fetched without a login check.
        /// The user is returned to the user info page (or user index, with same checks as OnPostDelete), with nothing changed in the user repository.
        /// </summary>
        /// <returns>A redirect to the user info page, or index page if criteria(admin + accessing another user) are met.</returns>
        public IActionResult OnPostCancel(string username)
        {
            string sessionusername = HttpContext.Session.GetString("Username");
            CurrentUser = _urepo.GetUser(sessionusername);
            if (username != CurrentUser.Username && CurrentUser.Admin)
            {
                return RedirectToPage("Index");
            }
            return RedirectToPage("Info");
        }
    }
}
