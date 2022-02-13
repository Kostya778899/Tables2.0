using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Table/Container", fileName = "NewTableDatasContainer")]
public class TableDatasContainer : ScriptableObject
{
    [ContextMenuItem("Debug json of datas!", "DebugDatasJson")] public TableDatas Datas;


    private void DebugDatasJson() => Debug.Log(JsonUtility.ToJson(Datas, true));
}
