using UnityEngine;

namespace Project.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private PlayerInputManager _playerInputManager;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private float _baseSpeed = 5f;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Vector2 CurrentMovementDirection { get; private set; }
        
        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }

        private void Move(float deltaTime)
        {
            CurrentMovementDirection = _playerInputManager.PlayerActions.Move.ReadValue<Vector2>();

            _rigidbody.linearVelocity = CurrentMovementDirection * _baseSpeed;
        }
    }
}
