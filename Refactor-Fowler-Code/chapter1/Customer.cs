using System;
using System.Collections.Generic;

namespace RefactorCh1
{
    public class Customer
    {
        private String _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(String name)
        {
            _name = name;
        }

        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public String getName()
        {
            return _name;
        }

        public String statement()
        {          
            
            IEnumerable<Rental> rentals = _rentals.ToArray();
            String result = "Rental Record for " + getName() + "\n";

            foreach (Rental rental in _rentals)
            {
                //determine amounts for each line
                double thisAmount = rental.GetCharge();                                               

                //show figures for this rental
                result += "\t" + rental.getMovie().getTitle() + "\t" + (thisAmount.ToString()) + "\n";                
            }

            //add footer lines
            result += "Amount owed is " + GetTotalCharge().ToString() + "\n";
            result += "You earned " + getTotalFrequentRenterPoints().ToString() + " frequent renter points";
            return result;
        }

        private double getTotalFrequentRenterPoints()
        {
            int frequentRenterPoints = 0;

            foreach (Rental rental in _rentals)
            {
                frequentRenterPoints += rental.AddFrequentRenterPoints();
            }

            return frequentRenterPoints;
        }

        private double GetTotalCharge()
        {
            double totalAmount = 0;

            foreach (Rental rental in _rentals)
            {
                double thisAmount = getCharge(rental);
                totalAmount += thisAmount;
            }

            return totalAmount;
        }

        private double getCharge(Rental rental)
        {
            return rental.GetCharge();
        }
    }
}

// extract and break down complicated bits.
// rename variables to proper ones
// ask whether it actually belongs there? If not, extract and put it in the relevant class
// get rid of any temporary variables and replace them with queries - yes there is performance but it helps improve the code