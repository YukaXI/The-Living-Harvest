using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;



    public void Attack()
    {
        anim.SetBool("isAttacking", true);
    }
}
