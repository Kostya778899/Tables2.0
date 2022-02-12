using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Table", fileName = "NewTableDatas")]
public class TableDatas : ScriptableObject
{
    public Vector2Int ColumnsInPageCount = new Vector2Int(4, 10);
    public List<Cell.Datas> CellsDatas;
}
