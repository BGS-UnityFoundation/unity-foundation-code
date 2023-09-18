using System;

namespace UnityFoundation.Code
{
    public readonly struct XZ : IEquatable<XZ>
    {
        public int X { get; }
        public int Z { get; }
        public XZ Right => new(X + 1, Z);
        public XZ Forward => new(X, Z + 1);
        public XZ Backwards => new(X, Z - 1);
        public XZ Left => new(X - 1, Z);

        public XZ(int x, int z)
        {
            X = x;
            Z = z;
        }

        public bool Equals(XZ xz)
        {           
            return xz.X == X && xz.Z == Z;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * Z.GetHashCode();
        }

        public static bool operator ==(XZ xz, XZ xz2)
        {
            return Equals(xz, xz2);
        }

        public static bool operator !=(XZ xz, XZ xz2) => !(xz == xz2);

        public override string ToString()
        {
            return $"({X},{Z})";
        }

    }
}
