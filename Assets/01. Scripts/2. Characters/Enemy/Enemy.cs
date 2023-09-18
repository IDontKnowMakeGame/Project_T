using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Scripts.Behaviours.Enemy.AI;
using UnityEngine;

namespace Scripts.Characters.Enemy
{
    public class Enemy : Character
    {
        protected EnemyBrain brain;
        protected virtual void Start()
        {
            GetBehaviour<EnemyBrain>(out brain);
            brain.GetState("Idle").onEnter += () => Debug.Log("Idle");
        }

    }
}