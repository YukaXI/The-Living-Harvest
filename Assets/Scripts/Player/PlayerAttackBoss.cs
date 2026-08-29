using Project.Player;
using UnityEngine;
using FMODUnity;

public class PlayerAttackBoss : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    
    [SerializeField]
    private float _knockbackForce = 50f;
    public float stunTime = 1f;

    
    public void Awake()
    {
        _playerMovement = FindAnyObjectByType<PlayerMovement>();
    }
    
    public void DealDamageToBoss()
    {
        _playerMovement.isAttacking = false;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_playerMovement.attackPoint.position, _playerMovement.weaponRange, _playerMovement.enemyLayer);

        if (enemies.Length > 0 && enemies[0].CompareTag("Boss"))
        {
            enemies[0].GetComponent<EnemyBossHealth>().ChangeHealth(-_playerMovement.damage);
            enemies[0].GetComponent<EnemyBossKnockback>().Knockback(transform, _knockbackForce, stunTime);
            Debug.Log("Enemie Damaged");
        }
    }
}