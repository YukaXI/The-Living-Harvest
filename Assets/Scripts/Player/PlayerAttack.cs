using Project.Player;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private EnemyKnockback _enemyKnockback;
    
    [SerializeField]
    private float _knockbackForce;

    public void Awake()
    {
        _playerMovement = FindAnyObjectByType<PlayerMovement>();
        _enemyKnockback = FindAnyObjectByType<EnemyKnockback>();
    }
    
    public void DealDamage()
    {
        _playerMovement.isAttacking = false;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_playerMovement.attackPoint.position, _playerMovement.weaponRange, _playerMovement.enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().ChangeHealth(-_playerMovement.damage);
            enemies[0].GetComponent<EnemyKnockback>().Knockback(transform, _knockbackForce);
            Debug.Log("Enemie Damaged");
        }
    }
}
