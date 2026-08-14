using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float speed;

    private bool isChasing;

    public Transform target;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //if (isChasing == true)
        //{
            Vector2 direction = (target.position - transform.position).normalized;
            rb.linearVelocity = direction;
        //}
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
