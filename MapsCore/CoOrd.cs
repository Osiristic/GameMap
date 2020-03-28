using System;
namespace MapsCore
{
    public class CoOrd
    {
        public int X { get; }
        public int Y { get; }

        public CoOrd(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object other)
        {
            if(other is CoOrd)
            {
                return ((CoOrd)other).X == X && ((CoOrd)other).Y == Y;
            }

            return false;
        }

        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }
    }
}
