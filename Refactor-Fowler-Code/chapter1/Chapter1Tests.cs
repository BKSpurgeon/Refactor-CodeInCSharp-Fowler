using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using RefactorCh1;

namespace Refactor_Fowler_Code.chapter1
{
    [TestFixture]
    class Chapter1Tests
    {

        [TestCase]
        public void Statement_EnterMovie_ReturnMovieStatement()
        {
            Customer c = new Customer("Freddie");
            Movie badbois = new Movie("Bad Boyz III", 1);
            
            //Movie monster = new Movie("Monsters Inc", 2);
            //Movie godfather = new Movie("Monsters Inc", 3);

            Rental r1 = new Rental(badbois, 5);
            //Rental r2 = new Rental(monster, 2);
            //Rental r3 = new Rental(godfather, 1);

            c.addRental(r1);
            //c.addRental(r2);
            //c.addRental(r3);

            string result = c.statement();
            Assert.AreEqual(result, "Rental Record for Freddie\n\tBad Boyz III\t15\nAmount owed is 15\nYou earned 2 frequent renter points");
        }
    }
}
