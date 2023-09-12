using System;
using System.Collections.Generic;
using Scripts.Behaviours.Enemy.AI.Base;
using Scripts.Managers;
using Scripts.Managers.Base;
using UnityEngine;

namespace Scripts.Utilities.Core
{
    public static class Define
    {
        private static Vector2Int _mapSize;
        
        public static Vector2Int MapSize
        {
            get => _mapSize;
            set => _mapSize = value;
        }
        
        public static bool IsInMap(Vector2Int position)
        {
            return position.x >= 0 && position.x < _mapSize.x && position.y >= 0 && position.y < _mapSize.y;
        }
        
        private static readonly Dictionary<Type, Manager> Managers = new ();
        
        public static void AddManager<T>() where T : Manager, new()
        {
            var manager = new T();
            Managers.Add(manager.GetType(), manager);
            manager.Init(GameManager.Instance);
        }

        public static T GetManager<T>() where T : Manager
        {
            return (T)Managers[typeof(T)];
        }
        
        private static Camera _mainCamera; 
        public static Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }

                return _mainCamera;
            }
        }

        public static Vector2Int GetGridPosition(this Vector3 position)
        {
            var pos = new Vector2(position.x, position.z);
            var gridPos = Vector2Int.RoundToInt(pos);
            return gridPos;
        }
        
        public static Vector3 GetWorldPosition(this Vector2Int gridPos)
        {
            var pos = new Vector3(gridPos.x, 0, gridPos.y);
            return pos;
        }
        
        public static readonly Dictionary<ECondition, Func<InputData, bool>> Conditions = new()
        {
            { ECondition.None, (x) => true },
            { ECondition.Time, Time }
        };
        
        private static float _time = 0;
        public static bool Time(InputData value)
        {
            var result = false;

            _time += UnityEngine.Time.deltaTime;
            if (_time >= (value.floatVal))
            {
                _time = 0;
                result = true;
            }

            return result;
        }
    }
}