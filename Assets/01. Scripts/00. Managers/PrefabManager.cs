using System;
using System.Collections.Generic;
using Scripts.Managers.Base;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Scripts.Managers
{
    public class PrefabManager : Manager
    {
        private Dictionary<string, Dictionary<string, GameObject>> _prefabs = new();

        public GameObject GetPrefabs(string category, string name)
        {
            return _prefabs[category][name];
        }

        public void LoadPrefabs(Action callBack)
        {
            var locationHandler = Addressables.LoadResourceLocationsAsync("Prefabs");

            locationHandler.Completed += (handler) =>
            {
                var locations = handler.Result;
                foreach (var location in locations)
                {
                    Debug.Log(location.PrimaryKey);
                    var categories = location.PrimaryKey.Split('/');
                    var objectHandler = Addressables.LoadAssetAsync<GameObject>(location.PrimaryKey);

                    objectHandler.Completed += (handler2) =>
                    {
                        var result = handler2.Result;

                        AddPrefab(categories[1], categories[2].Replace(".prefab", ""), result);
                        
                        
                        callBack?.Invoke();
                    };
                }
            };
        }

        private void AddPrefab(string category, string name, GameObject prefab)
        {
            _prefabs.TryAdd(category, new Dictionary<string, GameObject>());
            _prefabs[category].Add(name, prefab);
        }
    }
}