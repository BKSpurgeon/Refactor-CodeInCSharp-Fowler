using System;

namespace RefactorCh1
{
    public class Movie
    {
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        public const int CHILDRENS = 2;

        private String _title;
        private int _priceCode;

        public Movie(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public int getPriceCode()
        {
            return _priceCode;
        }

        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }

        public String getTitle()
        {
            return _title;
        }
    }
}