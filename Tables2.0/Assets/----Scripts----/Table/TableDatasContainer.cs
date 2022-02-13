using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Table/Container", fileName = "NewTableDatasContainer")]
public class TableDatasContainer : ScriptableObject
{
    [ContextMenuItem("Debug json of datas!", "DebugDatasJson")] public TableDatas Datas;

    [System.Serializable]
    private class SerializeDatas
    {
        public List<HorizontalColumnDatas> HorizontalColumnDatas;

        public SerializeDatas(List<HorizontalColumnDatas> horizontalColumnDatas)
        {
            HorizontalColumnDatas = horizontalColumnDatas;
        }
    }
    [System.Serializable]
    private class HorizontalColumnDatas
    {
        public List<string> Texts;

        public HorizontalColumnDatas(List<string> texts)
        {
            Texts = texts;
        }
    }

    public void LoadDatas(string json)
    {
        Datas = new TableDatas();
        Datas.Texts = new List<List<string>>();
        SerializeDatas serializeDatas = JsonUtility.FromJson<SerializeDatas>(json);

        for (int y = 0; y < serializeDatas.HorizontalColumnDatas.Count; y++)
        {
            Datas.Texts.Add(new List<string>());
            for (int x = 0; x < serializeDatas.HorizontalColumnDatas[y].Texts.Count; x++)
            {
                Datas.Texts[y].Add(serializeDatas.HorizontalColumnDatas[y].Texts[x]);
            }
        }
    }

    private void DebugDatasJson()
    {
        Datas = new TableDatas();
        Datas.Texts = new List<List<string>>();
        Datas.Texts.Add(new List<string>() { "000", "001", "002", "003", });
        Datas.Texts.Add(new List<string>() { "010", "011", "012", "013", });
        Datas.Texts.Add(new List<string>() { "020", "021", "022", "023", });
        Datas.Texts.Add(new List<string>() { "030", "031", "032", "033", });
        Datas.Texts.Add(new List<string>() { "040", "041", "042", "043", });
        Datas.Texts.Add(new List<string>() { "050", "051", "052", "053", });
        Datas.Texts.Add(new List<string>() { "060", "061", "062", "063", });
        Datas.Texts.Add(new List<string>() { "070", "071", "072", "073", });
        Datas.Texts.Add(new List<string>() { "080", "081", "082", "083", });
        Datas.Texts.Add(new List<string>() { "090", "091", "092", "093", });

        SerializeDatas serializeDatas = new SerializeDatas(new List<HorizontalColumnDatas>(Datas.Texts.Count));
        for (int i = 0; i < Datas.Texts.Count; i++)
            serializeDatas.HorizontalColumnDatas.Add(new HorizontalColumnDatas(Datas.Texts[i]));

        Debug.Log(JsonUtility.ToJson(serializeDatas, true));
    }
}
