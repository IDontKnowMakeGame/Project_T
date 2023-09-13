using System;
using DG.Tweening;
using Scripts.Managers;
using Scripts.Managers.Base;
using Scripts.Utilities.Core;
using UnityEngine;

namespace Scripts.Behaviours
{
    public class CharacterMovement : Behaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField]
        [Range(0f, 100f)] private float percent;
        private bool _isMoving;

        private Vector3 movePos;

        private void Start()
        {
            movePos = transform.position;

            InputManager.onMove += Translate;
        }

        private void Translate(Vector3 direction)
        {
            Move(movePos + direction);
        }
        
        private void Move(Vector3 position)
        {
            if (_isMoving) return;
            if (Define.IsInMap(position.GetGridPosition()) == false) return;
            movePos = position;
            _isMoving = true;
            var seq = DOTween.Sequence();
            seq.Append(transform.DOMove(movePos, 1 / speed).SetEase(Ease.Linear));
            seq.InsertCallback((1 / speed) * (percent * 0.01f), () => _isMoving = false);
        }

        private void Jump(Vector3 position)
        {
            if (_isMoving) return;
            if (Define.IsInMap(position.GetGridPosition()) == false) return;
            
            _isMoving = true;
            var seq = DOTween.Sequence();
            seq.Append(transform.DOJump(position, 1, 1, 1 / speed).SetEase(Ease.Linear));
            seq.AppendCallback(() => _isMoving = false);
        }
    }
}