using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().ChangeHealth(damage);
        }
    }
}
