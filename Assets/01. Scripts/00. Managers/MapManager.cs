using System.Collections.Generic;
using System.Numerics;
using Scripts.Managers.Base;
using Scripts.Tiles;
using Scripts.Utilities.Core;
using Scripts.Utilities.Data;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Scripts.Managers
{
    public class MapManager : Manager
    {
        private readonly Dictionary<Vector2, Tile> _map = new();

        public void AddTile(Tile tile)
        {
            _map.Add(tile._tileData.position, tile);
        }

        public void LoadMap(MapData data)
        {
            var tilePrefab = Manager<PrefabManager>.Instance.GetPrefabs("Objects", "Tile");
            var mapTrm = GameObject.Find("Map").transform;
            var dPos = Vector3.zero;

            var count = 0;
            for (var h = 0; h < data.mapSize.y; h++)
            {
                for (var w = 0; w < data.mapSize.x; w++)
                {
                    var tileObject = GameObject.Instantiate(tilePrefab, mapTrm);
                    tileObject.name = $"Tile #{count}";
                    tileObject.transform.localPosition = new Vector3(w, 0, h);
                    dPos += new Vector3(w,h);
                    count++;
                }
            }

            dPos /= count;
            var camPos = new Vector3(0, 10, -10);
            Define.MainCamera.transform.position = dPos + camPos;
        }
    }
}