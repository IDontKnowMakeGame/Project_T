using System;
using Scripts.Actors;
using Scripts.Utilities.Core;
using Scripts.Utilities.Data;
using UnityEngine;

namespace Scripts.Characters
{
    public class Character : Actor
    {
        private void Awake()
        {
            _actorData = new Info();
            _actorData.position = transform.position.GetGridPosition();
            transform.position = _actorData.position.GetWorldPosition();   
        }
    }
}