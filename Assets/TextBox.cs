using Scripts.Managers;
using Scripts.Managers.Base;
using Scripts.Utilities.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
	[SerializeField]
	private Text _nameText;

	[SerializeField]
	private Text _scriptText;

	private float _maxTimer = 0f;
	private float _timer = 0f;

	private string _text;

	private bool _onText = false;

	private int currentIndex = 0;

	private void Start()
	{
		OnText(Define.GetManager<DialogueManager>().OnChapterStart(),0.1f);
	}

	private void OnText(string text, float maxTimer = 0f)
	{
		_maxTimer = maxTimer;
		_text = text;
		_onText = true;
	}

	private void Update()
	{
		if(_onText)
		{
			if(_maxTimer >= _timer)
			{
				_timer += Time.deltaTime;
			}
			else
			{
				_timer = 0f;
				_scriptText.text = _text.Substring(0,currentIndex++);
			}

			if (_text.Length < currentIndex)
				_onText = false;
		}
	}
}
