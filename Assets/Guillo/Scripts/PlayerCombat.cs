using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    private CapsuleCollider meleeCollider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        meleeCollider = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Attack();
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        meleeCollider.isTrigger = true;
        Invoke("DisableMeleeCollider", 0.5f);
    }
    
    void DisableMeleeCollider()
    {
        meleeCollider.isTrigger = false;
    }
}
