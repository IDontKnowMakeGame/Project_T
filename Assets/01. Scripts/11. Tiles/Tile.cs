using System;
using Scripts.Characters;
using Scripts.Managers;
using Scripts.Managers.Base;
using Scripts.Utilities.Core;
using Scripts.Utilities.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Tiles
{
    public class Tile : MonoBehaviour
    {
        public Info tileData;
        public Character characterOnTile;

        private void Awake()
        {
            
        }

        public void Init()
        {
            tileData.position = transform.position.GetGridPosition();
            transform.position = tileData.position.GetWorldPosition();   
            Manager<MapManager>.Instance.AddTile(this);
        }
        public void SetCharacter(Character character)
        {
            characterOnTile = character;
        }
    }
}