namespace UnityFoundation.Code
{
    public class XZ
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

        public override bool Equals(object obj)
        {
            var otherPosition = obj as XZ;

            if(otherPosition == null) return false;

            return otherPosition.X == X && otherPosition.Z == Z;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * Z.GetHashCode();
        }

        public override string ToString()
        {
            return $"({X},{Z})";
        }
    }
}
