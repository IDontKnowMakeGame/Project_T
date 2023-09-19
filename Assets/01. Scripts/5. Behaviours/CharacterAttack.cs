using System;
using Scripts.Managers;
using Scripts.Managers.Base;
using Scripts.Utilities.Core;
using UnityEngine;

namespace Scripts.Behaviours
{
    public class CharacterAttack : Behaviour
    {
        [SerializeField]
        private Vector2 ImpactOffsetXZ;

        private CharacterRenderer _characterRenderer;

        private void Start()
        {
            _characterRenderer = GetComponentInChildren<CharacterRenderer>();
            InputManager.onAttackDown += Attack;
        }

        private void Attack()
        {
            _characterRenderer.ChangeAnimation(_characterRenderer.GetAnimationData(2));

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

                ChooseLeftOrRight(direction);

                var character = block.characterOnTile;
                owner.GetBehaviour<CharacterStat>(out var curStat);
                character.Damage(curStat.Atk);

            }
        }

        private void ChooseLeftOrRight(Vector2Int direction)
        {
            Vector3 playerScale = _characterRenderer.transform.localScale;

            if (direction == Vector2Int.left)
            {
                playerScale.x = -(Mathf.Abs(playerScale.x));
            }
            else if (direction == Vector2Int.right)
            {
                playerScale.x = (Mathf.Abs(playerScale.x));
            }

            _characterRenderer.transform.localScale = playerScale;
        }
    }
}