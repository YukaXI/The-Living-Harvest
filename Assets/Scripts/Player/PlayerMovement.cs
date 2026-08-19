using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Hash
        
        private static readonly int HashActionTrigger = Animator.StringToHash("ActionTrigger");
        
        private static readonly int HashActionId = Animator.StringToHash("ActionId");
        
        #endregion

        
        #region Enums
        
        public enum PlayerMovementState{Idle, Move}
        public enum PlayerAttackStates{Default, Attack}
        
        #endregion
        
        public Transform attackPoint;
        public float weaponRange = 1;
        public LayerMask enemyLayer;
        public int damage = 1;
        
        [Header("Player States")]
        [SerializeField] public PlayerMovementState playerMovementState;

        [SerializeField] public PlayerAttackStates playerAttackStates;

        
        [SerializeField]
        private PlayerInputManager _playerInputManager;
        
        [SerializeField]
        private PlayerStates _playerStates;
        
        [SerializeField]
        private Animator anim;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;
        [SerializeField]
        private float _baseSpeed = 5f;
        [SerializeField]
        private float cooldown = 2;
        [SerializeField] 
        private float timer;
        
        
        
        public Rigidbody2D Rigidbody => _rigidbody;
        public Vector2 CurrentMovementDirection { get; private set; }

        private void Awake()
        {
            _playerStates = GetComponent<PlayerStates>();
            anim = GetComponentInChildren<Animator>();
        }
        
        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
            
            playerMovementState = CurrentMovementDirection.magnitude == 0 ? PlayerMovementState.Idle : PlayerMovementState.Move;

        }

        private void Update()
        {
            if (PauseController.IsGamePaused)
                return;
            
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
        }

        private void Move(float deltaTime)
        {
            if (PauseController.IsGamePaused)
            {
                _rigidbody.linearVelocity = Vector2.zero;
                CurrentMovementDirection = Vector2.zero;
                return;
            }
            CurrentMovementDirection = _playerInputManager.PlayerActions.Move.ReadValue<Vector2>();

            _rigidbody.linearVelocity = CurrentMovementDirection * _baseSpeed;
        }
        
        public void Attack(InputAction.CallbackContext context)
        {
            if (timer <= 0)
            {
                timer = cooldown;
                AnimationSetActionId(1);

                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);
                playerAttackStates = PlayerAttackStates.Attack;
            }
            
            
        }

        public void AttackEnde(InputAction.CallbackContext ctx)
        {
            anim.SetBool("isAttacking", false);
            playerAttackStates = PlayerAttackStates.Default;
        }
        
        private void AnimationSetActionId(int id)
        {
            anim.SetTrigger(HashActionTrigger); 
            anim.SetInteger(HashActionId, id);
        }

    }
}
