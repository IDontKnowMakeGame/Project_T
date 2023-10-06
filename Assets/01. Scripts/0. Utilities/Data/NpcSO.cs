using UnityEngine;

[CreateAssetMenu(fileName = "NpcData", menuName = "Data/NPCData")]
public class NpcSO : ScriptableObject
{
    [SerializeField] AudioClip voiceClip;
    [SerializeField] Sprite npcSprite;

    public AudioClip VoiceClip => voiceClip;
    public Sprite NpcSprite => npcSprite;
}
