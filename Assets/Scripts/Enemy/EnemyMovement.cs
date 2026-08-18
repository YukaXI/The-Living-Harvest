using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private static readonly int BackAnimationHashTrigger = Animator.StringToHash("BackTrigger");
    private static readonly int FrontAnimationHashTrigger = Animator.StringToHash("FrontTrigger");
    private static readonly int SideAnimationHashTrigger = Animator.StringToHash("SideTrigger");
    
    
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float speed;

    private Animator _anim; 
    
    private bool isChasing;

    private int facingDirectionX = -1;
    
    public Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //if (isChasing == true)
        //{

//if (enemyState != enemyState.knockback)
        {
            MovementState();
        }
        
    }

    private void MovementState()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        
        if (target.position.x > transform.position.x && facingDirectionX == -1 || target.position.x < transform.position.x && facingDirectionX == 1)
        {
            SideAnimation();
        }

        if (target.position.y > transform.position.y)
        {
            FrontAnimation();
        }
        
        else if (target.position.y > transform.position.y)
        {
            BackAnimation();
        }
        
        rb.linearVelocity = direction;
    }

    private void SideAnimation()
    {
        facingDirectionX *= -1;
        _anim.SetTrigger(SideAnimationHashTrigger);
        transform.localScale = new Vector3(-transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void FrontAnimation()
    {
        _anim.SetTrigger(FrontAnimationHashTrigger);
        transform.localScale = new Vector3(transform.localScale.y * -1, transform.localScale.x, transform.localScale.z);
    }

    private void BackAnimation()
    {
        _anim.SetTrigger(BackAnimationHashTrigger);
        transform.localScale = new Vector3(-transform.localScale.y * 1, transform.localScale.x, transform.localScale.z);
    }
    
    public enum EnemyState
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
