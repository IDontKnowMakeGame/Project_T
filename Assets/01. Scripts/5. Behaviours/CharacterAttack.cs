using System;
using Scripts.Managers;
using Scripts.Managers.Base;
using Scripts.Utilities.Core;
using UnityEngine;

namespace Scripts.Behaviours
{
    public class CharacterAttack : Behaviour
    {
        private void Start()
        {
            InputManager.onAttackDown += Attack;
        }

        private void Attack()
        {
            var directions = new[]
            {
                Vector2Int.up,
                Vector2Int.down,
                Vector2Int.left,
                Vector2Int.right
            };
            
            foreach (var direction in directions)
            {
                var attackPos = owner.actorData.position + direction;
                
                if (Define.IsInMap(attackPos) == false) continue;

                var block = Manager<MapManager>.Instance.GetTile(attackPos);
                if (!block) continue;
                if (!block.characterOnTile) continue;

                var character = block.characterOnTile;
                owner.GetBehaviour<CharacterStat>(out var curStat);
                character.Damage(curStat.Atk);

            }
        }
    }
}