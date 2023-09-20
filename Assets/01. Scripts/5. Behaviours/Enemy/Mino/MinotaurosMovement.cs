using DG.Tweening;
using Scripts.Actors;
using Scripts.Behaviours;
using Scripts.Managers;
using Scripts.Utilities.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts.Behaviours.Enemy.Minotauros
{
    public class MinotaurosMovement : CharacterMovement
    {
		private Actor _actor;

		private Sequence _seq;

		public void Start()
		{
			_actor = GetComponent<Actor>();
		}

		public void MinoCharge()
		{
			Vector3 direction = ((Vector2)(Define.Player.actorData.position - _actor.actorData.position)).normalized;
			Vector2Int dir = new Vector2Int(Mathf.CeilToInt(direction.x), Mathf.CeilToInt(direction.y));
			MapManager mapManager = Define.GetManager<MapManager>();
			int index = 1;
			direction = new Vector3(dir.x, 0, dir.y);

			if (direction == Vector3.zero || (direction.x != 0 && direction.y != 0))
				return;

			while(mapManager.GetTile(_actor.actorData.position + dir * index) != null)
			{
				Vector3 temp = _actor.transform.position + direction * index;
				index++;
				_seq.Append(_actor.transform.DOLocalMove(temp, 0.3f));
				_seq.AppendCallback(() =>
				{
					//_actor.transform.position = _actor.transform.localPosition;
				});
			}
		}

		public void MinoStrike()
		{
			Jump(Define.Player.transform.position);
		}
	}
}