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
        public void TestAddValid()
        {
            UserRepository repo = new UserRepository();
            User testUser = new User();
            testUser.Username = "uniquetest";
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
        [TestMethod]
        public void TestAddInvalid()
        {
            UserRepository repo = new UserRepository();
            User testUser = new User();
            testUser.Username = "test";
            testUser.Password = "test";
            testUser.Email = "test";
            testUser.Name = "test";
            testUser.Admin = true;
            testUser.MembershipType = (MembershipType)3;
            repo.AddUser(testUser);
            int countbefore = repo.GetAllUsers().Count();
            User badUser = new User();
            badUser.Username = "test";
            badUser.Password = "bad";
            repo.AddUser(badUser);
            int countafter = repo.GetAllUsers().Count();
            Assert.AreEqual(countbefore, countafter);
        }

        [TestMethod]
        public void TestRemoveValid()
        {
            UserRepository repo = new UserRepository();
            User testUser = new User();
            testUser.Username = "test";
            testUser.Password = "test";
            testUser.Email = "test";
            testUser.Name = "test";
            testUser.Admin = true;
            testUser.MembershipType= (MembershipType)3;
            repo.AddUser(testUser);
            int countbefore = repo.GetAllUsers().Count();
            repo.DeleteUser("test");
            int countafter = repo.GetAllUsers().Count();
            Assert.AreEqual(countbefore, countafter+1);
        }

        [TestMethod]
        public void TestRemoveInvalid()
        {
            UserRepository repo = new UserRepository();
            User testUser = new User();
            testUser.Username = "test";
            testUser.Password = "test";
            testUser.Email = "test";
            testUser.Name = "test";
            testUser.Admin = true;
            testUser.MembershipType = (MembershipType)3;
            repo.AddUser(testUser);
            int countbefore = repo.GetAllUsers().Count();
            repo.DeleteUser("bad");
            int countafter = repo.GetAllUsers().Count();
            Assert.AreEqual(countbefore, countafter);
        }

        [TestMethod]
        public void TestGetValid()
        {
            UserRepository repo = new UserRepository();
            User testUser = new User();
            testUser.Username = "test";
            testUser.Password = "test";
            testUser.Email = "test";
            testUser.Name = "test";
            testUser.Admin = true;
            testUser.MembershipType = (MembershipType)3;
            repo.AddUser(testUser);
            User fetchedUser = repo.GetUser("test");
            Assert.AreEqual(testUser, fetchedUser);
        }
        [TestMethod]
        public void TestGetInvalid()
        {
            UserRepository repo = new UserRepository();
            User testUser = new User();
            testUser.Username = "test";
            testUser.Password = "test";
            testUser.Email = "test";
            testUser.Name = "test";
            testUser.Admin = true;
            testUser.MembershipType = (MembershipType)3;
            repo.AddUser(testUser);
            User fetchedUser = repo.GetUser("bad");
            Assert.AreNotEqual(testUser, fetchedUser);
        }

        [TestMethod]
        public void TestUpdateValid()
        {
            UserRepository repo = new UserRepository();
            User testUser = new User();
            testUser.Username = "test";
            testUser.Password = "test";
            testUser.Email = "test";
            testUser.Name = "test";
            testUser.Admin = true;
            testUser.MembershipType = (MembershipType)3;
            repo.AddUser(testUser);
            User newUser = new User();
            newUser.Username = "test";
            newUser.Password = "test";
            newUser.Email = "newtest";
            newUser.Name = "newtest";
            newUser.Admin = true;
            newUser.MembershipType =(MembershipType)2;
            repo.UpdateUser(newUser);
            Assert.AreEqual(repo.GetUser("test"), newUser);
        }
        [TestMethod]
        public void TestUpdateInvalid()
        {
            UserRepository repo = new UserRepository();
            User testUser = new User();
            testUser.Username = "test";
            testUser.Password = "test";
            testUser.Email = "test";
            testUser.Name = "test";
            testUser.Admin = true;
            testUser.MembershipType = (MembershipType)3;
            repo.AddUser(testUser);
            User newUser = new User();
            newUser.Username = "bad";
            newUser.Password = "test";
            newUser.Email = "newtest";
            newUser.Name = "newtest";
            newUser.Admin = true;
            newUser.MembershipType = (MembershipType)2;
            repo.UpdateUser(newUser);
            Assert.AreNotEqual(repo.GetUser("test"), newUser);
        }
    }
}
