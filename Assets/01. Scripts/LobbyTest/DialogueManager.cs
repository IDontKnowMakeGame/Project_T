using Scripts.Managers.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Manager
{
	private List<ChapterSO> _chapterSO
	{
		get
		{
			int index = 1;

			if (_chapterSOList.Count > 0)
				return _chapterSOList;

			while (Resources.Load("SOFolder/Dialogue/Chapter/Chapter" + index) != null)
			{
				_chapterSOList.Add(Resources.Load("SOFolder/Dialogue/Chapter/Chapter" + index) as ChapterSO);
				index++;
			}

			return _chapterSOList;
		}
	}

	private List<ChapterSO> _chapterSOList = new List<ChapterSO>();
	

	private int _currentChapterIndex = 0;
	private int _currentPageIndex = 0;
	private int _currentScriptIndex = 0;

	public event Action<string> _startTextBox;

	public string OnChapterStart()
	{
		if (_currentChapterIndex >= _chapterSO.Count)
			return null;

		if (_currentPageIndex >= _chapterSO[_currentChapterIndex].pageCount)
			return null;

		if (_currentScriptIndex >= _chapterSO[_currentChapterIndex].
			pages[_currentPageIndex].scriptsCount)
			return null;

		_startTextBox?.Invoke(_chapterSO[_currentChapterIndex].
			pages[_currentPageIndex].
			scripts[_currentScriptIndex].line);

		return _chapterSO[_currentChapterIndex].
			pages[_currentPageIndex].
			scripts[_currentScriptIndex].line;
	}
}
