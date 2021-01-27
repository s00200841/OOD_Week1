using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Week1
{
    public abstract class Band : IComparable
    {
        // Propetries
        public string BandName { get; set; }
        public int YearFormed { get; set; } // changing year from int to date time late i think : TODO change this 
        public string  Members { get; set; }

        // Constructors
        public Band(string bandName, int yearFormed, string members)
        {
            BandName = bandName;
            YearFormed = yearFormed;
            Members = members;
        }

        // Default Constructor
        public Band()
        {

        }

        public override string ToString()
        {
            return BandName;
        }

        public int CompareTo(object obj)
        {
            Band otherband = obj as Band;
            return this.BandName.CompareTo(otherband.BandName);
        }
    }

    public class RockBand : Band
    {
        public override string ToString()
        {
            return base.ToString() + " - Rock Band";
        }
    }

    public class GrungeBand : Band
    {
        public override string ToString()
        {
            return base.ToString() + " - Grunge Band";
        }
    }
    public class MetalBand : Band
    {
        public override string ToString()
        {
            return base.ToString() + " - Metal Band";
        }
    }
}
