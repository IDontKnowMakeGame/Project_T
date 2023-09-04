using UnityEngine;

namespace Scripts.Managers.Base
{
    public class Manager : MonoBehaviour
    {
        public static Manager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            } else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}