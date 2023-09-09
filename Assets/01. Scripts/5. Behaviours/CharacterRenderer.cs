using Scripts.Utilities.Data;
using UnityEngine;

namespace Scripts.Behaviours
{
    public class CharacterRenderer : Behaviour
    {
        [SerializeField] private AnimationData initialAnimationData;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();

            if (initialAnimationData)
            {
                _renderer.material = initialAnimationData.material;
            }
            
        }
    }
}