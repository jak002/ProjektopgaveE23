using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        Dictionary<string,User> GetAllUsers();
        User GetUser(string username);
        public void UpdateUser(User updatedUser);
        void DeleteUser(string username);
        public User? VerifyUser(string username, string password);
    }
}
