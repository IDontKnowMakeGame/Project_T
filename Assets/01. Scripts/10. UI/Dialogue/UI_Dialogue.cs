using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class UI_Dialogue : MonoBehaviour
{
    public TMP_Text textBox;
    public AudioClip typingClip;
    public AudioSourceGroup audioSourceGroup;
    DialogueAnimator dialogueAnimator;

    private void Awake()
    {
        dialogueAnimator = new DialogueAnimator(textBox, audioSourceGroup);
    }

    private void Update()
    { 

    }

    private Coroutine typeRoutine = null;

    void PlayDialogue(string message)
    {
        this.EnsureCoroutineStopped(ref typeRoutine);
        dialogueAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialoguUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueAnimator.AnimateTextIn(commands, totalTextMessage, typingClip, null));
    }
}
