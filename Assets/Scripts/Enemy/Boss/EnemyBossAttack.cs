using System;
using UnityEngine;

public class EnemyBossAttack : MonoBehaviour
{
    [SerializeField]
    private int damage;

    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float attackPointOffset;
    
    [SerializeField]
    private float weaponRange;
    public LayerMask playerLayer;
    
    private Animator _anim;
    private EnemyBossMovement _enemyBossMovement;

    private void Awake()
    {
        _enemyBossMovement = GetComponent<EnemyBossMovement>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_enemyBossMovement.facingDirectionY == 1)
        {
            attackPoint.localPosition = new Vector3(0, attackPointOffset, 0);
        }
        
        else if (_enemyBossMovement.facingDirectionY == -1) 
        {
            attackPoint.localPosition = new Vector3(0, -attackPointOffset, 0);
        }
        
        else if (_enemyBossMovement.facingDirectionX == 1) 
        {
            attackPoint.localPosition = new Vector3(attackPointOffset, 0, 0);
        }
        
        else if (_enemyBossMovement.facingDirectionX == -1) 
        {
            attackPoint.localPosition = new Vector3(attackPointOffset, 0, 0);
        }
    }

    public void EnemyAttackMethod()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0)
        {
            _enemyBossMovement._enemyAnimationState = EnemyBossMovement.EnemyAnimationStates.Attacking;
            hits[0].GetComponentInChildren<PlayerHealth>().ChangeHealth(-damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}