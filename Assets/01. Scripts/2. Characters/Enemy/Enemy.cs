using System;
using Scripts.Behaviours.Enemy.AI;
using UnityEngine;

namespace Scripts.Characters.Enemy
{
    public class Enemy : Character
    {
        private void Start()
        {
            GetBehaviour<EnemyBrain>(out var brain);
            brain.GetState("Idle").onEnter += () => Debug.Log("Idle");
            brain.GetState("Stamp").onEnter += () => Debug.Log("Stamp");
        }
    }
}