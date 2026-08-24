using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossKnockback : MonoBehaviour
{
    
    private EnemyBossMovement _enemyBossMovement;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyBossMovement = GetComponent<EnemyBossMovement>();
    }
    
    public void Knockback(Transform playerTransform, float knockbackForce, float stunTime)
    {
        _enemyBossMovement._enemyAnimationState = EnemyBossMovement.EnemyAnimationStates.Knockback;
        StartCoroutine(StunTimer(stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        _rb.linearVelocity = direction * knockbackForce;
        
        Debug.Log("Knockback applied");
    }

    IEnumerator StunTimer(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        _rb.linearVelocity = Vector2.zero;
        _enemyBossMovement._enemyAnimationState = EnemyBossMovement.EnemyAnimationStates.Move;
    }
    
    //Quelle: https://www.youtube.com/watch?v=mhtVz0MiEGc
}