using System;
using DG.Tweening;
using Scripts.Managers;
using Scripts.Managers.Base;
using Scripts.Utilities.Core;
using UnityEngine;
using System.Collections.Generic;

namespace Scripts.Behaviours
{
    public class CharacterMovement : Behaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField]
        [Range(0f, 100f)] private float percent;
        private bool _isMoving;
        private bool _useInsert = true;

        private CharacterRenderer _characterRenderer;

        private Queue<Vector3> moveQueue;

        private void Awake()
        {
            _characterRenderer = GetComponentInChildren<CharacterRenderer>();
            moveQueue = new Queue<Vector3>();
        }

        private void Start()
        {
            InputManager.onMove += InsertMoveQueue;
        }

        private void InsertMoveQueue(Vector3 direction)
        {
            if (!_useInsert) return;

            moveQueue.Enqueue(direction);

            if (!_isMoving && moveQueue.Count == 1)
            {
                Translate();
            }
        }

        private void Translate()
        {
            if(moveQueue.Count > 0)
            {
                Vector3 dir = moveQueue.Dequeue();
                Move(dir);
            }
            else
            {
                _characterRenderer.ChangeAnimation(_characterRenderer.GetAnimationData(0));
            }
        }

        private void ChooseLeftOrRight(Vector3 direction)
        {
            Vector3 playerScale = _characterRenderer.transform.localScale;

            if(direction == Vector3.left)
            {
                playerScale.x = -(Mathf.Abs(playerScale.x));
            }
            else if(direction == Vector3.right)
            {
                playerScale.x = (Mathf.Abs(playerScale.x));
            }

            _characterRenderer.transform.localScale = playerScale;
        }
        
        private void Move(Vector3 dir)
        {
            Vector3 position = transform.position + dir;

            if (Define.IsInMap(position.GetGridPosition()) == false) return;

            _isMoving = true;
            _useInsert = false;

            ChooseLeftOrRight(dir);
            _characterRenderer.ChangeAnimation(_characterRenderer.GetAnimationData(1));

            var seq = DOTween.Sequence();
            seq.Append(transform.DOMove(position, 1 / speed).SetEase(Ease.Linear));
            seq.InsertCallback((1 / speed) * (percent * 0.01f), () => 
            {
                _useInsert = true;
            });
            seq.AppendCallback(() => 
            {
                _isMoving = false;
                Translate();
            });
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