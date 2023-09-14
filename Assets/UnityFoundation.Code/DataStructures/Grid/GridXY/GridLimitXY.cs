using System;
using System.Collections.Generic;

namespace UnityFoundation.Code
{
    [Serializable]
    public class GridLimitXY : IGridLimits<XY>
    {
        public int Width { get; }
        public int Height { get; }

        public int PositionsCount => Width * Height;

        public GridLimitXY(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int GetIndex(XY coordinate)
        {
            return coordinate.X * Width + coordinate.Y;
        }

        public XY GetPosition(int index)
        {
            return new(index / Width, index % Width);
        }

        public IEnumerable<int> GetIndexes()
        {
            foreach(var coord in GetPositions())
                yield return GetIndex(coord);
        }

        public IEnumerable<XY> GetPositions()
        {
            for(int x = 0; x < Width; x++)
                for(int y = 0; y < Height; y++)
                    yield return new(x, y);
        }

        public bool IsInside(XY coordinate)
        {
            return coordinate.X >= 0
                && coordinate.X < Width
                && coordinate.Y >= 0
                && coordinate.Y < Height;
        }

        public XY[] GetNeighbours(XY position)
        {
            var neighbours = new List<XY>();
            AppendNeighbour(neighbours, position.Right);
            AppendNeighbour(neighbours, position.Up);
            AppendNeighbour(neighbours, position.Left);
            AppendNeighbour(neighbours, position.Down);
            return neighbours.ToArray();
        }

        private void AppendNeighbour(List<XY> neighbours, XY position)
        {
            if(IsInside(position))
                neighbours.Add(position);
        }
    }
}
