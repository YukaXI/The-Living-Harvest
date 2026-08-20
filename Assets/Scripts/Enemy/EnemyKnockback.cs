using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    
    private EnemyMovement _enemyMovement;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyMovement = FindAnyObjectByType<EnemyMovement>();

    }
    
    public void Knockback(Transform playerTransform, float knockbackForce)
    {
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        _rb.linearVelocity = direction * knockbackForce;
        Debug.Log("Knockback applied");
    }
    
    //Quelle: https://www.youtube.com/watch?v=mhtVz0MiEGc
}
