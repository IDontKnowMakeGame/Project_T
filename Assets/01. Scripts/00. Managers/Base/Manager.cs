using System;
using Scripts.Utilities.Core;
using UnityEngine;

namespace Scripts.Managers.Base
{
    public abstract class Manager
    {
        protected GameManager Parent { get; private set; }
        public void Init(GameManager manager)
        {
            Parent = manager;
        }
    }

    public class Manager<T> where T : Manager
    {
        public static T Instance
        {
            get => Define.GetManager<T>();
        }
    }
}