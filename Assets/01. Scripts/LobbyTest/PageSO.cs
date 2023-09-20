using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Script
{
	public string name;
	public string line;

	public Script(string nameTack, string lines)
	{
		name = nameTack;
		line = lines;
	}

}
[CreateAssetMenu(fileName = "PageSO", menuName = "Create DialogueSO/Page")]
public class PageSO : ScriptableObject
{
	public List<Script> scripts = new List<Script>();
	public int scriptsCount => scripts.Count;

	public void ScriptClear() => scripts?.Clear();
}
