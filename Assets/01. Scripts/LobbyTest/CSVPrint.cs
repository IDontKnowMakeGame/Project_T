using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System.IO;
using Unity.VisualScripting;

public class CSVPrint : EditorWindow
{
	private string _text;

	public string ID { get; private set; }
	public string Gid { get; private set; }
	public string StartIdx { get; private set; }
	public string EndIdx { get; private set; }

	[MenuItem("Tools/CSVPrintWindow")]
	public static void ShowCSVPrint()
	{
		EditorWindow.GetWindow(typeof(CSVPrint));
	}

	public void OnGUI()
	{
		ID = EditorGUILayout.TextField("ID", ID);
		Gid = EditorGUILayout.TextField("Gid", Gid);
		StartIdx = EditorGUILayout.TextField("Sindex", StartIdx);
		EndIdx = EditorGUILayout.TextField("Eindex", EndIdx);

		if (GUILayout.Button("불러와주기!", GUILayout.Width(128)))
		{
			string url;
            url = $"https://docs.google.com/spreadsheets/d/{ID}/export?format=csv&gid={Gid}&range={StartIdx}:{EndIdx}";
			DataUpdate(url);
		}
	}


	private async void DataUpdate(string URL)
	{
		UnityWebRequest www = UnityWebRequest.Get(URL);
		await www.SendWebRequest();
		string data = www.downloadHandler.text;
		Debug.Log(data);
		CSVConverter.ConvertingCSV(data);
	}
}
