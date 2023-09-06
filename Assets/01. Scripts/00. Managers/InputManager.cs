using System;
using Scripts.Managers.Base;
using UnityEngine;

namespace Scripts.Managers
{
    public class InputManager : Manager
    {
        public static Action<Vector3> onMoveDown;
        public static Action<Vector3> onMove;
        public static Action<Vector3> onMoveUp;

        public override void Init(GameManager manager)
        {
            base.Init(manager);
            GameManager.onGameUpdate += CheckInput;
        }

        private void CheckInput()
        {
            if(Input.GetKeyDown(KeyCode.W))
                onMoveDown?.Invoke(Vector3.forward);
            if(Input.GetKeyDown(KeyCode.S))
                onMoveDown?.Invoke(Vector3.back);
            if(Input.GetKeyDown(KeyCode.A))
                onMoveDown?.Invoke(Vector3.left);
            if(Input.GetKeyDown(KeyCode.D))
                onMoveDown?.Invoke(Vector3.right);
        }
    }
}