using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolaArbolB
{
    public class Enteros : IComparable
    {
        public int NumeroInt { get; set; }
        public int CompareTo(object obj)
        {
            if (Convert.ToInt16(this.CompareTo(obj)) > 0)
                return 1;
            else if (Convert.ToInt16(this.CompareTo(obj)) < 0)
                return -1;
            else
                return 0;
        }
    }
}
