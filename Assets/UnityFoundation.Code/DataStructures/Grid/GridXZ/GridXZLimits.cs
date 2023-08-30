using System.Collections.Generic;

namespace UnityFoundation.Code
{
    public class GridXZLimits : IGridLimits<XZ>
    {
        public int Width { get; }
        public int Depth { get; }
        public int PositionsCount => Width * Depth;

        public GridXZLimits(int width, int depth)
        {
            Width = width;
            Depth = depth;
        }

        public int GetIndex(XZ coordinate)
        {
            return coordinate.X * Depth + coordinate.Z;
        }

        public IEnumerable<int> GetIndexes()
        {
            for(int x = 0; x < Width; x++)
                for(int z = 0; z < Depth; z++)
                    yield return GetIndex(new XZ(x, z));
        }

        public IEnumerable<XZ> GetPositions()
        {
            foreach(var index in GetIndexes())
                yield return GetPosition(index);
        }

        public XZ GetPosition(int index)
        {
            return new(index / Depth, index % Depth);
        }

        public bool IsInside(XZ coordinate)
        {
            return coordinate.X >= 0
                && coordinate.X < Width
                && coordinate.Z >= 0
                && coordinate.Z < Depth;
        }
    }
}
