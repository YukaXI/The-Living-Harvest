using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private static readonly int BackAnimationHashTrigger = Animator.StringToHash("BackTrigger");
    private static readonly int FrontAnimationHashTrigger = Animator.StringToHash("FrontTrigger");
    private static readonly int SideAnimationHashTrigger = Animator.StringToHash("SideTrigger");
    
    
    [SerializeField] private Rigidbody2D rb;
    private Transform player;

    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance = 1f;

    private Animator _anim; 
    
    private bool isChasing;

    private int facingDirectionX = -1;
    private int facingDirectionY = 0;
    
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
    }

    private void MovementState()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        
        if (target.position.x > transform.position.x && facingDirectionX == -1 || target.position.x < transform.position.x && facingDirectionX == 1)
            
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0 && facingDirectionX < 0)
            {
                FlipX(1);
                _anim.SetTrigger(SideAnimationHashTrigger);
            }
            else if (direction.x < 0 && facingDirectionX > 0)
            {
                FlipX(-1);
                _anim.SetTrigger(SideAnimationHashTrigger);
            }
        }
        else
        {
            if (direction.y > 0)
            {
                _anim.SetTrigger(BackAnimationHashTrigger);
            }
            else if (direction.y < 0)
            {
               _anim.SetTrigger(FrontAnimationHashTrigger);
            }
        }

        {
           // SideAnimation();
        }

        //if (target.position.y > transform.position.y)
        {
            //FrontAnimation();
        }

        //else if (target.position.y > transform.position.y)
        {
            //BackAnimation();
        }

       rb.linearVelocity = direction * speed;
    }


    private void FlipX(int newDirectionX)
    {
        facingDirectionX = newDirectionX;

        Vector3 currentScale = transform.localScale;
        transform.localScale = new Vector3(Mathf.Abs(currentScale.x) * facingDirectionX, currentScale.y, currentScale.z);
    }

    /*private void SideAnimation()
    {
        //facingDirectionX *= -1;
        //_anim.SetTrigger(SideAnimationHashTrigger);
        //transform.localScale = new Vector3(-transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    /*private void FrontAnimation()
    {
        //_anim.SetTrigger(FrontAnimationHashTrigger);
        //transform.localScale = new Vector3(transform.localScale.y * -1, transform.localScale.x, transform.localScale.z);
    }

    /*private void BackAnimation()
    {
        //_anim.SetTrigger(BackAnimationHashTrigger);
        //transform.localScale = new Vector3(-transform.localScale.y * 1, transform.localScale.x, transform.localScale.z);
    }

    /*public enum EnemyState
    {
        Knockback,
        Chasing
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
