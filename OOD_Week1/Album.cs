using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Week1
{
    public class Album
    {
        // Messing with int YearOfRelease to be DateTime
        // Properties
        public string Name { get; set; }
        public DateTime YearOfRelease { get; set; }
        public int Sales { get; set; }

        // Constructors
        public Album(string name, DateTime yearOfRelease, int sales)
        {
            Name = name;
            YearOfRelease = yearOfRelease;
            Sales = sales;
        }

        // Default Constructor
        public Album()
        {

        }

        // Methods
        public override string ToString()
        {
            return string.Format($"{Name} - Released in : {YearOfRelease.Day} : {YearOfRelease.Month} : {YearOfRelease.Year} - Sales of : {Sales} " +
                $"              \nThis Album was released {CalculateYearsSinceRelease()} Year(s) ago.");
        }

        public int CalculateYearsSinceRelease()
        {
            return DateTime.Now.Year - YearOfRelease.Year;
        }

    }
}
