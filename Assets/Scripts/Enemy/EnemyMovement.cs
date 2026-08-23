using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    #region Private Hashes
    
    private static readonly int BackAnimationHashTrigger = Animator.StringToHash("BackTrigger");
    private static readonly int FrontAnimationHashTrigger = Animator.StringToHash("FrontTrigger");
    private static readonly int SideAnimationHashTrigger = Animator.StringToHash("SideTrigger");
    
    public static readonly int AttackHashBool = Animator.StringToHash("isAttacking");
        
    #endregion
    
     
    #region public enums
        
    public enum EnemyAnimationStates{Move, Attacking, Knockback}
        
    #endregion
    
    #region private and public Variables
    
    [SerializeField] private Rigidbody2D rb;
    private Transform player;
    private Animator _anim;


    [SerializeField] private float speed;
    
    [Header("Enemy Movement States")]
    public EnemyAnimationStates _enemyAnimationState;
    
    [Header("Attack Setup")]
    public float attackRange = 2;
    public float attackCooldown = 2f;
    private float attackCooldownTimer;
    
    [SerializeField] private Transform stoppingPoint;
    [SerializeField] private float stoppingDistance = 0f; //Abstand zum Gegner 
    
    private Slider _slider;
    
    private bool isChasing;

    public int facingDirectionX = -1; //checkt die X-Achse es Gegners
    public int facingDirectionY = 0; //checkt die Y-Achse des Gegners
    
    public Transform target;

    #endregion

    #region Unity Events
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _slider = GetComponentInChildren<Slider>();
    }

    private void FixedUpdate()
    {
        if (_enemyAnimationState == EnemyAnimationStates.Knockback) return;

            if (target == null) return;

            float distanceToTarget = Vector2.Distance(transform.position, target.position);


            if (distanceToTarget <= stoppingDistance)
            {
                rb.linearVelocity = Vector2.zero;
                _anim.SetBool(AttackHashBool, true);

                facingDirectionX = 0;
                facingDirectionY = 0;
            }

            else
            {
                _anim.SetBool(AttackHashBool, false);
                MovementState();
            }
        
    }
    
    #endregion

    #region Movement
    
    private void MovementState()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            int targetDirX = direction.x > 0 ? 1 : -1;
            
            if (facingDirectionX != targetDirX) 
            {
                FlipX(targetDirX);
                facingDirectionY = 0;
                _anim.SetTrigger(SideAnimationHashTrigger);

                if (facingDirectionX == 1)
                {
                    _slider.transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                else
                {
                    _slider.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
        }
        else
        {
            if (direction.y > 0 && facingDirectionY != 1)
            {
                facingDirectionY = 1;
                facingDirectionX = 0;
                _anim.SetTrigger(BackAnimationHashTrigger);
            }
            else if (direction.y < 0 && facingDirectionY != -1)
            {
                facingDirectionY = -1;
                facingDirectionX = 0;
               _anim.SetTrigger(FrontAnimationHashTrigger);
              
            }
        }

       rb.linearVelocity = direction * speed;
    }


    private void FlipX(int newDirectionX)
    {
        facingDirectionX = newDirectionX;

        Vector3 currentScale = transform.localScale;
        transform.localScale = new Vector3(Mathf.Abs(currentScale.x) * facingDirectionX, currentScale.y, currentScale.z);
    }
    
    #endregion
    
    #region Gizmo
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(stoppingPoint.position, stoppingDistance);
    }
    
    #endregion
    
    #region Methods for Enemy: Normal behaviour 

/*private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        if (target == null)
        {
            target = collision.transform;
        }
        isChasing = true;
    }
}


private void OnTriggerExit2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        isChasing = false;
    }
}
*/

#endregion
}

//Quelle: https://www.youtube.com/watch?v=IEadGWvewsA&t=152s&pp=0gcJCRMMAYcqIYzv Enemy Reihe 
