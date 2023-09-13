using Scripts.Behaviours;
using Scripts.Managers;

namespace Scripts.Characters.Player
{
    public class Player : Character
    {
        CharacterMovement _movement;
        protected override void Init()
        {
            base.Init();
            GetBehaviour(out _movement);
            InputManager.onMove += _movement.Translate;
        }
    }
}