using System;
using Scripts.Managers;
using Scripts.Managers.Base;
using Scripts.Utilities.Core;
using Scripts.Utilities.Data;
using UnityEngine;

namespace Scripts.Tiles
{
    public class Tile : MonoBehaviour
    {
        public Info _tileData;

        private void Awake()
        {
            _tileData = new Info();
            Manager<MapManager>.Instance.AddTile(this);
        }
    }
}