using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryForCustomer.model
{
    public class Customer
    {
        public Customer(int id, string firstName, string lastName, int year)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Year = year;
        }

        public Customer()
        {
            Id = -666;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            return $"Customer : {Id} : {FirstName} : {LastName} : {Year}";
        }
    }

    
}
