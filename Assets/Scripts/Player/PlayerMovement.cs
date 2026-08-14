using System;
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

        public Transform attackPoint;
        public float weaponRange = 1;
        public LayerMask enemyLayer;
        public int damage = 1;
        
        [SerializeField]
        private PlayerInputManager _playerInputManager;
        
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
        
        public bool isAttacking = false;
        
        public Rigidbody2D Rigidbody => _rigidbody;
        public Vector2 CurrentMovementDirection { get; private set; }

        private void Awake()
        {
            anim = GetComponentInChildren<Animator>();
        }
        
        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }

        private void Update()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
        }

        private void Move(float deltaTime)
        {
            CurrentMovementDirection = _playerInputManager.PlayerActions.Move.ReadValue<Vector2>();

            _rigidbody.linearVelocity = CurrentMovementDirection * _baseSpeed;
        }
        
        public void Attack(InputAction.CallbackContext context)
        {
            if (timer <= 0)
            {
                isAttacking = true;
                timer = cooldown;
                AnimationSetActionId(1);
            }
            
            DealDamage();
        }

        public void DealDamage()
        {
            isAttacking = false;
            
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

            if (enemies.Length > 0)
            {
                enemies[0].GetComponent<EnemyHealth>().ChangeHealth(-damage);
                Debug.Log("Enemie Damaged");
            }
        }

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

    }
}
