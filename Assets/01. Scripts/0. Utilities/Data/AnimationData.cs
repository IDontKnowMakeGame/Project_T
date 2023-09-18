using UnityEngine;

namespace Scripts.Utilities.Data
{
    [CreateAssetMenu(fileName = "AnimationData", menuName = "Data/AnimationData")]
    public class AnimationData : ScriptableObject
    {
        public Texture texture;
        public Material material;
        public int columns;
        public int rows;
        public int totalFrames;
        public float moveSecond;
        public bool loop;
        public int nextIdx;
        // ---------------------------------
        public string nextAnimation;
        public int currentFrame;
    }
}