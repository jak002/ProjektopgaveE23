using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectopgaveE23test
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void TestGetAll()
        {
            UserRepository repo = new UserRepository();
            Dictionary<string,User> testDict = repo.GetAllUsers();
            Assert.IsNotNull(testDict);
        }

        [TestMethod]
        public void TestAdd()
        {
            UserRepository repo = new UserRepository();
            User testUser = new User();
            testUser.Username = "test";
            testUser.Password = "test";
            testUser.Email = "test";
            testUser.Name = "test";
            testUser.Admin = true;
            testUser.MembershipType = (MembershipType)3;
            int countbefore = repo.GetAllUsers().Count();
            repo.AddUser(testUser);
            int countafter = repo.GetAllUsers().Count();
            Assert.AreEqual(countbefore+1, countafter);
        }

    }
}
