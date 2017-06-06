using System;

namespace RefactorCh1
{
    public class Movie
    {
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        public const int CHILDRENS = 2;

        private String _title;
        private Price _priceCode;

        public Movie(String title, int priceCode)
        {
            _title = title;
            setPriceCode(priceCode);
        }

        public int getPriceCode()
        {
            return _priceCode.getPriceCode();
        }

        /// <summary>
        /// Sets the price code. This is the factory method, basically
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <exception cref="ArgumentException">\n Cannot pass in that integer.</exception>
        public void setPriceCode(int arg)
        {
            switch (arg)
            {
                case REGULAR:
                    _priceCode = new RegularPrice();
                    break;
                case NEW_RELEASE:
                    _priceCode = new NewReleasePrice();
                    break;
                case CHILDRENS:
                    _priceCode = new ChildrensPrice();
                    break;
                default:
                    throw new ArgumentException("\n Cannot pass in that integer.");
            }

        }

        public String getTitle()
        {
            return _title;
        }

        public double GetCharge(int daysRented)
        {
            return _priceCode.GetCharge(daysRented);
        }


        public int AddFrequentRenterPoints(int daysRented)
        {
            

            int frequentRenterPoints = 0;

            frequentRenterPoints++;
            // add bonus for a two day new release rental
            if ((getPriceCode() == Movie.NEW_RELEASE) && daysRented > 1)
            {
                frequentRenterPoints++;
            }

            return frequentRenterPoints;
        }
    }

    public abstract class Price
    {
        public abstract int getPriceCode();

        public abstract double GetCharge(int daysRented);

        public virtual int AddFrequentRenterPoints(int daysRented)
        {            
            return 1;
        }
    }

    class ChildrensPrice : Price
    {
        public override int getPriceCode()
        {
            return Movie.CHILDRENS;
        }

        public override double GetCharge(int daysRented)
        {
            double charge = 1.5;
            if (daysRented > 3)
            {
                charge += (daysRented - 3) * 1.5;
            }
            return charge;
        }
    }

    class NewReleasePrice : Price
    {
        public override int getPriceCode()
        {
            return Movie.NEW_RELEASE;
        }

        public override double GetCharge(int daysRented)
        {
            double charge = 0;
            charge += daysRented * 3;
            return charge;
        }

        public override int AddFrequentRenterPoints(int daysRented)
        {
            int frequentRenterPoints = 0;

            frequentRenterPoints++;
            // add bonus for a two day new release rental
            if ((getPriceCode() == Movie.NEW_RELEASE) && daysRented > 1)
            {
                frequentRenterPoints++;
            }

            return frequentRenterPoints;
        }
    }

    class RegularPrice : Price
    {
        public override int getPriceCode()
        {
            return Movie.REGULAR;
        }

        public override double GetCharge(int daysRented)
        {
             double charge = 2;
                    if (daysRented > 2)
                    {
                        charge += (daysRented - 2) * 1.5;
                    }
            return charge;
        }
    }
}