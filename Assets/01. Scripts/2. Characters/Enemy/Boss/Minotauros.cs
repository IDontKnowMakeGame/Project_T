using Scripts.Behaviours.Enemy.Minotauros;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Characters.Enemy.Boss
{
    public class Minotauros : Enemy
    {
        MinotaurosMovement _minoMovement;

		protected override void Init()
		{
			base.Init();
			GetBehaviour(out _minoMovement);
		}

		protected override void Start()
		{
			base.Start();

			brain.GetState("Charge").onEnter += () => _minoMovement.MinoCharge();
			brain.GetState("Charge").onEnter += () => { Debug.Log("Charge"); };
			brain.GetState("Strike").onEnter += () => _minoMovement.MinoStrike();
		}
	}
}
