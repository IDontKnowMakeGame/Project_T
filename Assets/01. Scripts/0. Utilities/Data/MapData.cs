using UnityEngine;

namespace Scripts.Utilities.Data
{
    [CreateAssetMenu(fileName = "MapData", menuName = "Data/MapData")]
    public class MapData : ScriptableObject
    {
        public string mapName;
        public Vector2Int mapSize;
        public int[,] mapData;
    }
}