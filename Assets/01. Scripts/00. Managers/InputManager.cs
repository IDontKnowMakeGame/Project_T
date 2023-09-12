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
        
        public static Action onAttackDown;
        public static Action onAttack;
        public static Action onAttackUp;

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
            
            if(Input.GetKey(KeyCode.W))
                onMove?.Invoke(Vector3.forward);
            if(Input.GetKey(KeyCode.S))
                onMove?.Invoke(Vector3.back);
            if(Input.GetKey(KeyCode.A))
                onMove?.Invoke(Vector3.left);
            if(Input.GetKey(KeyCode.D))
                onMove?.Invoke(Vector3.right);
            
            
            if(Input.GetKeyDown(KeyCode.K))
                onAttackDown?.Invoke();
            if(Input.GetKey(KeyCode.K))
                onAttack?.Invoke();
            if(Input.GetKeyUp(KeyCode.K))
                onAttackUp?.Invoke();
        }
    }
}