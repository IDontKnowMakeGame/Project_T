using System;
using Scripts.Actors;
using Scripts.Managers;
using Scripts.Managers.Base;
using Scripts.Tiles;
using Scripts.Utilities.Core;
using Scripts.Utilities.Data;
using UnityEngine;

namespace Scripts.Characters
{
    public class Character : Actor
    {
        private Tile _currentTile;
        private void Awake()
        {
            actorData.position = transform.position.GetGridPosition();
            transform.position = actorData.position.GetWorldPosition();
        }

        private void Update()
        {
            actorData.position = transform.position.GetGridPosition();
            var tile = Manager<MapManager>.Instance.GetTile(actorData.position);
            if (!tile) return;
            if (tile == _currentTile) return;
            if(_currentTile)
                _currentTile.SetCharacter(null);
            tile.SetCharacter(this);
            _currentTile = tile;
        }
    }
}