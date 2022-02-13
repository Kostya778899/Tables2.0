using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Table/Loaders/FromWeb", fileName = "NewTableDatasLoaderFromWeb")]
public class TableDatasLoaderFromWeb : TableDatasLoaderDefault
{
    [SerializeField] private string _url = "";


    public override Task<TableDatas> Get()
    {
        var datas = new TableDatas();

        return null;
    }
}
