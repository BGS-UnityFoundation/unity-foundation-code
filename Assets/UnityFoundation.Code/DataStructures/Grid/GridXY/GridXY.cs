using System.Collections.Generic;

namespace UnityFoundation.Code
{
    public class GridXY<TValue> : BaseGrid<GridLimitXY, GridCell<TValue>, XY, TValue>
        where TValue : new()
    {
        public GridXY(GridLimitXY limits) : base(limits)
        {
            
        }

        protected override void InitializeCells(Dictionary<int, GridCell<TValue>> cells)
        {
            foreach(var index in Limits.GetIndexes())
                cells.Add(index, new());
        }
    }
}
