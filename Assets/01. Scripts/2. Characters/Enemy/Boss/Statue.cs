using DG.Tweening;
using Scripts.Behaviours;
using Scripts.Behaviours.Enemy.Statue;
using Scripts.Utilities.Core;

namespace Scripts.Characters.Enemy.Boss
{
    public class Statue : Enemy
    {
        private StatueMovement _movement;

        protected override void Init()
        {
            base.Init();
            GetBehaviour(out _movement);
        }

        protected override void Start()
        {
            GetBehaviour(out _movement);
            base.Start();

            _movement.moveComplete += () =>
            {

            };
            brain.GetState("Stamp").onEnter += () => _movement.Move(Define.Player.actorData.position.GetWorldPosition());
        }
    }
}