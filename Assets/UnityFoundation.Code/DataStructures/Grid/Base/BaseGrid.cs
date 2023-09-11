using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityFoundation.Code
{
    public class BaseGrid<TGridLimits, TGridCell, TPosition, TValue> : IGrid<TPosition, TValue>
        where TGridLimits : IGridLimits<TPosition>
        where TGridCell : IGridCell<TValue>, new()
        where TValue : new()
    {
        private readonly Dictionary<int, TGridCell> cells;
        private readonly TGridLimits limits;
        public BaseGrid(TGridLimits limits)
        {
            this.limits = limits;

            cells = new();
            foreach(var index in limits.GetIndexes())
                cells.Add(index, new());
        }

        public IGridLimits<TPosition> Limits => limits;
        public void ChangeValues(TPosition pos1, TPosition pos2)
        {
            var pos1Value = GetValue(pos1);
            var pos2Value = GetValue(pos2);

            Clear(pos1);
            Clear(pos2);

            SetValue(pos1, pos2Value);
            SetValue(pos2, pos1Value);
        }

        public void Clear(TPosition coordinate)
        {
            GetCell(coordinate).Clear();
        }

        public void Clear()
        {
            foreach(var cell in cells.Values)
                cell.Clear();
        }

        public TPosition GetPosition(TValue value)
        {
            foreach(var cell in cells)
            {
                if(EqualityComparer<TValue>.Default.Equals(cell.Value.GetValue(), value))
                {
                    return limits.GetPosition(cell.Key);
                }
            }

            return default;
        }

        public TValue GetValue(TPosition coordinate)
        {
            return GetCell(coordinate).GetValue();
        }

        public IEnumerable<TValue> GetValues()
        {
            foreach(var cell in cells.Values)
                yield return cell.GetValue();
        }

        public bool IsInsideGrid(TPosition coordinate)
        {
            return limits.IsInside(coordinate);
        }
        public void SetValue(TPosition coordinate, TValue value)
        {
            GetCell(coordinate).SetValue(value);
        }

        public void SetValueForce(TPosition pos, TValue value)
        {
            Clear(pos);
            SetValue(pos, value);
        }

        public void UpdateValue(TPosition coordinate, Action<TValue> valueCallback)
        {
            valueCallback(GetCell(coordinate).GetValue());
        }

        private TGridCell GetCell(TPosition coordinate)
        {
            if(!IsInsideGrid(coordinate))
                throw new ArgumentOutOfRangeException($"Coordinate {coordinate} is not inside grid");

            return cells[limits.GetIndex(coordinate)];
        }
    }
}
