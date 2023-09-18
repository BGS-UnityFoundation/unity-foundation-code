using System;
using UnityEngine.UIElements;

namespace UnityFoundation.Code
{
    [Serializable]
    public readonly struct XY : IEquatable<XY>
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

        public bool Equals(XY xy)
        {
            return xy.X == X && xy.Y == Y;
        }

        public static bool operator ==(XY xy, XY xy2)
        {
            return Equals(xy, xy2);
        }

        public static bool operator !=(XY xy, XY xy2) => !(xy == xy2);

        public override string ToString() => $"({X}, {Y})";

        public override int GetHashCode() => X + Y;


    }
}
