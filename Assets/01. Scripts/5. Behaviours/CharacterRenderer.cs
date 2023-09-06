using UnityEngine;

namespace Scripts.Behaviours
{
    public class CharacterRenderer : Behaviour
    {
        private Renderer _renderer;
        
        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }
    }
}