using TMPro;
using Scripts.Managers.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Managers 
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text textBox;
        [SerializeField] private List<NpcSO> npcSOList;
        [SerializeField] private AudioSourceGroup audioSourceGroup;

        [SerializeField] private Image NpcImage;
        [SerializeField] private TextMeshProUGUI NameText;

        DialogueAnimator dialogueAnimator;
        ExcelData excelData;

        private void Awake()
        {
            dialogueAnimator = new DialogueAnimator(textBox, audioSourceGroup);
            excelData = GetComponent<ExcelData>();
            StartCoroutine(excelData.Setting());

            excelData.settingOver -= FirstSetting;
            excelData.settingOver += FirstSetting;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                PlayingDialogue(0);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                PlayingDialogue(1);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayingDialogue(2);
            }
        }

        void FirstSetting()
        {
            PlayingDialogue(0);
        }

        public void PlayingDialogue(int id)
        {
            PlayDialogue(excelData.TextDataList[id]);
        }

        private Coroutine typeRoutine = null;
        void PlayDialogue(Textdata data)
        {
            NpcImage.sprite = npcSOList[data.NPC_ID].NpcSprite;
            NameText.text = data.Name;

            this.EnsureCoroutineStopped(ref typeRoutine);
            dialogueAnimator.textAnimating = false;
            List<DialogueCommand> commands = DialoguUtility.ProcessInputString(data.Content, out string totalTextMessage);
            typeRoutine = StartCoroutine(dialogueAnimator.AnimateTextIn(commands, totalTextMessage, npcSOList[data.NPC_ID].VoiceClip, null));
        }
    }
}

