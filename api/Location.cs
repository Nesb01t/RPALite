using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPALite.api
{
    public class Location
    {
        public int X;
        public int Y;

        public Location()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
