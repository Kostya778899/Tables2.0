using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Table/Loaders/BuilIn", fileName = "NewTableDatasLoaderBuilIn")]
public class TableDatasLoaderBuilIn : TableDatasLoaderDefault
{
    [TextArea(5, 35), SerializeField] private string _json;


    public override async Task<TableDatas> Get()
    {
        return JsonUtility.FromJson<TableDatas>(_json);
    }
}
