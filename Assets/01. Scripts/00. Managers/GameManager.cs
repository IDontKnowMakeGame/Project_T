using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Managers.Base;
using Scripts.Utilities.Core;
using Scripts.Utilities.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Managers
{
    public enum GameState
    {
        Loading,
        Playing,
        Paused,
    }
    
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        [SerializeField] private GameState currentState = GameState.Playing;
        [SerializeField] private MapData testMap = null;

        private void Awake()
        {
            Instance = this;
            AddManager();
        }

        private IEnumerator Start()
        {
            Load();
            yield return new WaitUntil(() => currentState == GameState.Playing);
            Manager<MapManager>.Instance.LoadMap(testMap);
        }

        private void Load()
        {
            currentState = GameState.Loading;
            Manager<PrefabManager>.Instance.LoadPrefabs(() => currentState = GameState.Playing);
        }

        private void AddManager()
        {
            Define.AddManager<PrefabManager>();
            Define.AddManager<MapManager>();
        }
    }
}