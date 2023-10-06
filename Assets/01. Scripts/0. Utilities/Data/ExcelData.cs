using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ExcelData : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/15aTYnn32mF4NgCWdO3DDh4izimksA541oao6Q3qslr8/export?format=tsv&range=A2:D";

    public Action settingOver; 

    public IEnumerator Setting()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        SetData(data);
    }

    List<Textdata> textDataList = new List<Textdata>();
    public List<Textdata> TextDataList => textDataList;

    void SetData(string data)
    {
        string[] row = data.Split('\n');
        int rowSize = row.Length;

        for(int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            Textdata textdata = new Textdata(column[1], column[2], int.Parse(column[3]));
            textDataList.Insert(int.Parse(column[0]), textdata);
        }
        settingOver.Invoke();
    }


}

public struct Textdata
{
    string _name;
    string _content;
    int _npcID;

    public string Name => _name;
    public string Content => _content;
    public int NPC_ID => _npcID;

    public Textdata(string name, string content, int npcID)
    {
        _name = name;
        _content = content;
        _npcID = npcID;
    }
}

