using System.Collections.Generic;

namespace UnityFoundation.Code
{
    /// <summary>
    /// Define os limites de um grid e todas as suas posições.
    /// </summary>
    /// <typeparam name="TPosition"></typeparam>
    public interface IGridLimits<TPosition>
    {
        int PositionsCount { get; }

        bool IsInside(TPosition position);
        int GetIndex(TPosition position);
        TPosition GetPosition(int index);
        IEnumerable<int> GetIndexes();
        IEnumerable<TPosition> GetPositions();
    }
}
