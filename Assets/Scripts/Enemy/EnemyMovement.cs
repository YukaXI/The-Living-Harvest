using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private static readonly int BackAnimationHashTrigger = Animator.StringToHash("BackTrigger");
    private static readonly int FrontAnimationHashTrigger = Animator.StringToHash("FrontTrigger");
    private static readonly int SideAnimationHashTrigger = Animator.StringToHash("SideTrigger");
    
    private static readonly int AttackHashBool = Animator.StringToHash("isAttacking");
    
    
    [SerializeField] private Rigidbody2D rb;
    private Transform player;

    [SerializeField] private Transform stoppingPoint;
    [SerializeField] private Transform attackPoint;

    [SerializeField] private float speed;
    
    [SerializeField] private float stoppingDistance = 0f; //Abstand zum Gegner 
    [SerializeField] private float attackRange = 0f;
    
    private Animator _anim;
    

    public EnemyState enemyState;
    
    private bool isChasing;

    private int facingDirectionX = -1; //checkt die X-Achse es Gegners
    private int facingDirectionY = 0; //checkt die Y-Achse des Gegners
    
    public Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            MovementState();
        }

        if (target == null) return;

        float distanceToTarget = Vector2.Distance(transform.position, target.position);

       
        if (distanceToTarget <= stoppingDistance)
        {
            rb.linearVelocity = Vector2.zero;
            _anim.SetBool(AttackHashBool, true); 
        }
        
        else
        {
            _anim.SetBool(AttackHashBool, false);
            MovementState();
        }
    }

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

    private void Attack()
    {
        
    }
    
    
    public enum EnemyState
    {
        Attacking,
        Knockback,
        Chasing
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(stoppingPoint.position, stoppingDistance);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
    

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
}

//Quelle: https://www.youtube.com/watch?v=IEadGWvewsA&t=152s&pp=0gcJCRMMAYcqIYzv Enemy Reihe 
