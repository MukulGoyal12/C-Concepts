using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    internal class Restaurant : IComparable<Restaurant>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Rating {  get; set; }

        public int CompareTo(Restaurant? other)
        {
            if (Rating > other.Rating)
            {
                return 1;
            }else if (Rating < other.Rating)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return $"{Id}\t {Name}\t {Location}\t {Rating}"; 
        }
    }

    class NameSorter : IComparer<Restaurant>
    {
        public int Compare(Restaurant? x, Restaurant? y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    class LocationSorter : IComparer<Restaurant>
    {
        public int Compare(Restaurant? x, Restaurant? y)
        {
            return x.Location.CompareTo(y.Location);
        }
    }

}
