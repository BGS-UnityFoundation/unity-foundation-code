using System;
using UnityEngine.UIElements;

namespace UnityFoundation.Code
{
    [Serializable]
    public class XY
    {
        public int X { get; }
        public int Y { get; }

        public XY(int x, int y)
        {
            X = x;
            Y = y;
        }

        public XY Right => new(X + 1, Y);
        public XY Up => new(X, Y + 1);
        public XY Left => new(X - 1, Y);
        public XY Down => new(X, Y - 1);

        public override bool Equals(object obj)
        {
            if(obj is not XY xy)
                return false;

            return xy.X == X && xy.Y == Y;
        }

        public override string ToString() => $"({X}, {Y})";

        public override int GetHashCode() => X + Y;
    }
}
