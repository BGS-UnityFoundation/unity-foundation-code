using System;

namespace UnityFoundation.Code
{
    public interface IGrid<TPosition, TValue>
    {
        IGridLimits<TPosition> Limits { get; }

        void ChangeValues(TPosition pos1, TPosition pos2);
        void Clear(TPosition coordinate);
        TPosition GetPosition(TValue value);
        TValue GetValue(TPosition coordinate);
        bool IsInsideGrid(TPosition coordinate);
        void SetValue(TPosition coordinate, TValue value);
        void UpdateValue(TPosition coordinate, Action<TValue> valueCallback);
    }
}
