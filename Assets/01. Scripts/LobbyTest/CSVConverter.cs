using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CSVConverter : MonoBehaviour
{
	private static ChapterSO chapterSo;

	public static void ConvertingCSV(string csv)
	{
		var lines = Regex.Split(csv, "\n");

		if (lines.Length <= 1) return;

		foreach (var line in lines)
		{
			var values = Regex.Split(line, ",");
			if (values.Length == 0 || values[0] == "") continue;

			int chapterIndex = int.Parse(values[0].ToString());
			if (chapterIndex < 0)
				return;

			Object chapterObj = Resources.Load("SOFolder/Dialogue/Chapter/Chapter" + chapterIndex);
			ChapterSO so = chapterObj as ChapterSO;

			if (chapterSo != so)
			{
				chapterSo = so;
				chapterSo?.PagesClear();
			}

			if (chapterSo != null)
			{
				int pageIndex = int.Parse(values[1].ToString());
				Object pageObject = Resources.Load("SOFolder/Dialogue/Page/Page" + chapterIndex + "-" + pageIndex);
				PageSO page = pageObject as PageSO;

				if (page == null)
				{
					var pageSO = ScriptableObject.CreateInstance<PageSO>();
					AssetDatabase.CreateAsset(pageSO, "Assets/Resources/SOFolder/Dialogue/Page/Page" + chapterIndex + "-" + pageIndex + ".asset");

					so.pages.Add(pageSO);
					pageSO.scripts.Add(new Script(values[2], values[3]));
				}
				else
				{
					page.scripts.Add(new Script(values[2], values[3]));
					so.pages.Add(page);
				}
			}
			else
			{
				var chapterso = ScriptableObject.CreateInstance<ChapterSO>();
				AssetDatabase.CreateAsset(chapterso, "Assets/Resources/SOFolder/Dialogue/Chapter/Chapter" + chapterIndex + ".asset");
				chapterSo = chapterso;

				int pageIndex = int.Parse(values[1].ToString());
				var pageSO = ScriptableObject.CreateInstance<PageSO>();
				AssetDatabase.CreateAsset(pageSO, "Assets/Resources/SOFolder/Dialogue/Page/Page" + chapterIndex + "-" + pageIndex + ".asset");
				chapterso.pages.Add(Resources.Load("SOFolder/Dialogue/Page/Page" + chapterIndex + "-" + pageIndex) as PageSO);

				pageSO.scripts.Add(new Script(values[2], values[3]));
			}
		}

		chapterSo = null;
	}
}
