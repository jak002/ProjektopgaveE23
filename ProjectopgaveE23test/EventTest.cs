using ProjektopgaveE23.Interfaces;
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
    public class EventTest
    {

        private EventRepository _eventRepository;

        private void TestSetUp()
        {
            _eventRepository = new EventRepository();
            Event e1 = new Event();
            Event e2 = new Event();
            _eventRepository.AddEvent(e1);
            _eventRepository.AddEvent(e2);
        }

        [TestMethod]
        public void TestAddEvent()
        {
            //arrange 
            TestSetUp();

            //act
            int numberBefore = _eventRepository.GetAllEvents().Count;
            Event e3 = new Event();
            _eventRepository.AddEvent(e3);
            int numberAfter = _eventRepository.GetAllEvents().Count;

            //assert
            Assert.AreEqual(numberBefore+1, numberAfter);

        }

        [TestMethod]
        public void TestDeleteEvent() 
        {
            //arrange 
            TestSetUp();

            //act
            Event e3 = new Event();
            _eventRepository.AddEvent(e3);
            int numberBefore = _eventRepository.GetAllEvents().Count;
            _eventRepository.DeleteEvent(e3);
            int numberAfter = _eventRepository.GetAllEvents().Count;

            //assert 
            Assert.AreNotEqual(numberBefore, numberAfter);
        
        }


    }
}
