using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityFoundation.Code
{
    public class GridXZ<TValue> : BaseGrid<GridXZLimits, GridCell<TValue>, XZ, TValue>
        where TValue : new()
    {
        public GridXZ(GridXZLimits limits) : base(limits)
        {
        }

        protected override void InitializeCells(Dictionary<int, GridCell<TValue>> cells)
        {
            foreach(var index in Limits.GetIndexes())
                cells.Add(index, new());
        }
    }
}
