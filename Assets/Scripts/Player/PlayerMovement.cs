using System;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

namespace Project.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Hash
        
        private static readonly int HashActionTrigger = Animator.StringToHash("ActionTrigger");
        private static readonly int HashActionId = Animator.StringToHash("ActionId");
        
        private static readonly int HashMovementDirX = Animator.StringToHash("dirX");
        private static readonly int HashMovementDirY = Animator.StringToHash("dirY");
        
        #endregion
       
        #region Enums
        
        public enum PlayerMovementState{Idle, Move}
        
        #endregion
        
        [Header("Player States")]
        [SerializeField] public PlayerMovementState playerMovementState;
        public bool canAttack;
        public Transform attackPoint;
        public float weaponRange = 1;
        public LayerMask enemyLayer;
        public int damage = 1;
        
        [Header("Movement Controlling")] public bool canMove = true;
        
        [Header("Inventory Setup")]
        public bool isPaused;
        
        [SerializeField] private GameObject _inventory;
        [SerializeField] private PlayerInputManager _playerInputManager;
        [SerializeField] private Animator anim;
        
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _baseSpeed = 5f;
        [SerializeField] private float cooldown = 2;
        [SerializeField] private float timer;

        [SerializeField] 
        private float attackPointOffset;
        
        public bool isAttacking = false;
        
        public Rigidbody2D Rigidbody => _rigidbody;
        public Vector2 CurrentMovementDirection { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            anim = GetComponentInChildren<Animator>();
            _inventory.SetActive(false);
            
        }
        
        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
            
            playerMovementState = CurrentMovementDirection.magnitude == 0 ? PlayerMovementState.Idle : PlayerMovementState.Move;
        }

        private void Update()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            
            AttackPointOffset();
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
            if (canAttack)
            {
                if (PauseController.IsGamePaused)
                    return;

                if (timer <= 0)
                {
                    isAttacking = true;
                    timer = cooldown;

                    AnimationSetActionId(1);

                    RuntimeManager.PlayOneShot("event:/SFX/Character/Interactions/SwordAttack");
                }
            }
        }

        #region Inventory
        
        public void Inventory(InputAction.CallbackContext context)
        {
            if (PauseController.IsGamePaused)
                ResumeGame();
            else
                PauseGame();

        }
        
        public void ResumeGame()
        {
            _inventory.SetActive(false);
            PauseController.SetPause(false);
        }

        public void PauseGame()
        {
            _inventory.SetActive(true);
            PauseController.SetPause(true);
        }
        
        #endregion
        

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
        }

        private void AnimationSetActionId(int id)
        {
            anim.SetTrigger(HashActionTrigger); 
            anim.SetInteger(HashActionId, id);
        }

        private void AttackPointOffset()
        {
            if (anim.GetFloat(HashMovementDirY) == 1)
            {
                attackPoint.localPosition = new Vector3(0, 1.3f, 0);
            }
        
            else if (anim.GetFloat(HashMovementDirY) == -1) 
            {
                attackPoint.localPosition = new Vector3(0, -0.4f, 0);
            }
        
            else if (anim.GetFloat(HashMovementDirX) == 1) 
            {
                attackPoint.localPosition = new Vector3(attackPointOffset, 0.5f, 0);
            }
        
            else if (anim.GetFloat(HashMovementDirX) == -1) 
            {
                attackPoint.localPosition = new Vector3(attackPointOffset, 0.5f, 0);
            }
        }
    }

}
