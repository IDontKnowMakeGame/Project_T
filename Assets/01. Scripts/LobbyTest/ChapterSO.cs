using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

[CreateAssetMenu(fileName = "ChapterSO", menuName = "Create DialogueSO/Chapter")]
public class ChapterSO : ScriptableObject
{
	public List<PageSO> pages = new List<PageSO>();
	public int pageCount => pages.Count;

	public void PagesClear()
	{
		foreach(PageSO page in pages)
		{
			page.ScriptClear();
		}
		pages.Clear();
	}
}
