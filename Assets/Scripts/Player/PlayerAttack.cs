using Project.Player;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    
    [SerializeField]
    private float _knockbackForce = 50f;
    public float stunTime = 1f;

    
    public void Awake()
    {
        _playerMovement = FindAnyObjectByType<PlayerMovement>();
    }
    
    public void DealDamage()
    {
        _playerMovement.isAttacking = false;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_playerMovement.attackPoint.position, _playerMovement.weaponRange, _playerMovement.enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().ChangeHealth(-_playerMovement.damage);
            enemies[0].GetComponent<EnemyKnockback>().Knockback(transform, _knockbackForce, stunTime);
            Debug.Log("Enemie Damaged");
        }
    }
}
