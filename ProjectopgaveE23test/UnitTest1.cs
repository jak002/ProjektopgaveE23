using ProjektopgaveE23.Models;
using ProjektopgaveE23.Services;

namespace ProjectopgaveE23test
{
    [TestClass]
    public class BoatRepositoryTest
    {
        BoatRepository repo;
        public void SetUp() 
        {  
            repo = new BoatRepository();
            Boat b1 = new Boat();
            repo.AddBoat(b1);
        }
        [TestMethod]
        public void Add_2Boat()
        {
            SetUp();
            int numbersBefore = repo.GetAllBoats().Count;
            Boat b2 = new Boat();
            repo.AddBoat(b2);
            int numbersAfter = repo.GetAllBoats().Count;

            Assert.AreEqual(numbersBefore+1, numbersAfter);
        }
    }
}