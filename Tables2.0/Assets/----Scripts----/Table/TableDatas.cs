using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TableDatas
{
    public Vector2Int ColumnsInPageCount/* = new Vector2Int(4, 10)*/;
    public List<Cell.Datas> CellsDatas;
}
