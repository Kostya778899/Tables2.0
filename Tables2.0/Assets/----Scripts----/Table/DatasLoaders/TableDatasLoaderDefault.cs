using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class TableDatasLoaderDefault : ScriptableObject
{
    public abstract Task<TableDatas> Get();
}
