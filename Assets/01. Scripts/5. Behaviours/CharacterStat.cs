using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Behaviours
{
    public class CharacterStat : Behaviour
    {
        [Serializable]
        private class Stat
        {
            public int value;
            public int maxValue;

            public void Init()
            {
                value = maxValue;
            }
        }
        
        [SerializeField]
        private Stat _hp = new();
        [SerializeField]
        private Stat _spd = new();
        [SerializeField]
        private Stat _atk = new();
        [SerializeField]
        private Stat _def = new();
        
        public int Hp => _hp.value;
        public int Spd => _spd.value;
        public int Atk => _atk.value;
        public int Def => _def.value;


        private void Awake()
        {
            _hp.Init();
            _spd.Init();
            _atk.Init();
            _def.Init();
        }

        private void Start()
        {
            Character.OnDamage += GetDamage;
        }

        public void GetDamage(int damage)
        {
            _hp.value -= damage;
            
            if (_hp.value >= 0) return;
            _hp.value = 0;
            owner.Invoke("Die", 0f);
        }
    }
}