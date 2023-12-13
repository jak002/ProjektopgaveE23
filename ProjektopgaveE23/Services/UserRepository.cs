using ProjektopgaveE23.Helpers;
using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Models;

namespace ProjektopgaveE23.Services
{
    public class UserRepository : IUserRepository
    {
        private string filePath = @"Data\JsonUsers.json";

        public void AddUser(User user)
        {
            string username = user.Username;
            Dictionary<string,User> currentDict = GetAllUsers();
            if (!currentDict.ContainsKey(username)) 
            {
                currentDict.Add(username, user);
                JsonFileWriter<User>.WriteToJson(currentDict.Values.ToList(), filePath);
            } else
            {
                throw new ArgumentException("Dette brugernavn er optaget. Vælg venligst et andet brugernavn");
            }
        }

        public void DeleteUser(string username)
        {
            Dictionary<string,User> currentDict = GetAllUsers();
            if (currentDict.ContainsKey(username)) 
            {
                currentDict.Remove(username);
                JsonFileWriter<User>.WriteToJson(currentDict.Values.ToList(), filePath);
            }
        }

        public Dictionary<string, User> GetAllUsers()
        {
            List<User> userlist = JsonFileReader<User>.ReadJson(filePath);
            Dictionary<string,User> userDict = new Dictionary<string,User>();
            foreach (var user in userlist)
            {
                userDict.Add(user.Username, user);
            }
            return userDict;
        }

        public User GetUser(string username)
        {
            foreach (var user in GetAllUsers())
            {
                if (user.Value.Username == username)
                    return user.Value;
            }
            return new User();
        }

        public void UpdateUser(User updatedUser)
        {
            if (updatedUser != null)
            {
                Dictionary<string,User> userDict = GetAllUsers();
                if (userDict.ContainsKey(updatedUser.Username))
                {
                    userDict[updatedUser.Username] = updatedUser;
                }
                JsonFileWriter<User>.WriteToJson(userDict.Values.ToList(), filePath);
            }
        }

        public User? VerifyUser(string username, string password)
        {
            foreach (var user in GetAllUsers().Values)
            {
                if (username.Equals(user.Username) && password.Equals(user.Password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
