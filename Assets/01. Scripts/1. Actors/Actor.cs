using System;
using System.Collections.Generic;
using Scripts.Utilities.Data;
using UnityEngine;
using UnityEngine.Serialization;
using Behaviour = Scripts.Behaviours.Behaviour;

namespace Scripts.Actors
{
    public class Actor : MonoBehaviour
    {
        public Info actorData;
        private readonly Dictionary<Type, Behaviour> _behaviours = new();

        protected virtual void Awake()
        {
            var behaviours = GetComponentsInChildren<Behaviour>();
            Debug.Log(behaviours.Length);
            foreach (var behaviour in behaviours)
            {
                Debug.Log(behaviour.GetType());
                behaviour.owner = this;
                _behaviours.Add(behaviour.GetType(), behaviour);
            }
            
            Init();
        }


        protected virtual void Init()
        {
            
        }
        
        public void GetBehaviour<T>(out T behaviour) where T : Behaviour
        {
            behaviour = (T)_behaviours[typeof(T)];
        }
    }
}