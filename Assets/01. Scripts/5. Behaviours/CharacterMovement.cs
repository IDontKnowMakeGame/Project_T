﻿using System;
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
        private bool _isMoving;
        private void Start()
        {
            InputManager.onMove += Translate;
        }

        private void Translate(Vector3 direction)
        {
            Move(transform.position + direction);
        }
        
        private void Move(Vector3 position)
        {
            if(_isMoving) return;
            if (Define.IsInMap(position.GetGridPosition()) == false) return;
            _isMoving = true;
            var seq = DOTween.Sequence();
            seq.Append(transform.DOMove(position, 1 / speed).SetEase(Ease.Linear));
            seq.AppendCallback(() => _isMoving = false);
        }
    }
}