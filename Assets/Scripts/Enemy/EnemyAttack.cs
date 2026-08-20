using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
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
    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_enemyMovement.facingDirectionY == 1)
        {
            attackPoint.localPosition = new Vector3(0, attackPointOffset, 0);
        }
        
        else if (_enemyMovement.facingDirectionY == -1) 
        {
            attackPoint.localPosition = new Vector3(0, -attackPointOffset, 0);
        }
        
        else if (_enemyMovement.facingDirectionX == 1) 
        {
            attackPoint.localPosition = new Vector3(attackPointOffset, 0, 0);
        }
        
        else if (_enemyMovement.facingDirectionX == -1) 
        {
            attackPoint.localPosition = new Vector3(attackPointOffset, 0, 0);
        }
    }

    public void EnemyAttackMethod()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0)
        {
            hits[0].GetComponentInChildren<PlayerHealth>().ChangeHealth(-damage);
            Debug.Log(hits[0].name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}
