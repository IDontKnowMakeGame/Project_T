using System;
using Scripts.Actors;
using Scripts.Characters;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Behaviours
{
    public class Behaviour : MonoBehaviour
    {
        public Actor owner;
        public Character Character => owner as Character;
    }
}