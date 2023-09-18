using System;
using DG.Tweening;
using Scripts.Utilities.Core;
using UnityEngine;

namespace Scripts.Behaviours.Enemy.Statue
{
    public class StatueMovement : CharacterMovement
    {
        public Action moveComplete = null;
        public override void Move(Vector3 position)
        {
            if (_isMoving) return;
            if (Define.IsInMap(position.GetGridPosition()) == false) return;
            
            _isMoving = true;
            var seq = DOTween.Sequence();
            seq.Append(transform.DOLocalMoveY(1, 0.5f));
            position.y = 1f;
            seq.Append(transform.DOMove(position, 0.3f));
            seq.Append(transform.DOLocalMoveY(0, 0.2f).SetEase(Ease.InExpo));
            seq.AppendCallback(() =>
            {
                moveComplete?.Invoke();
                _isMoving = false;
            });
        }
    }
}