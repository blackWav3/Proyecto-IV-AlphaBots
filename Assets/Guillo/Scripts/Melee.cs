using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public float fireRate;
    public int meleeDamage;
    float nextAtttackTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextAtttackTime)
        {
            Attack();
        }
    }
    void Attack()
    {
        nextAtttackTime = Time.time + fireRate;
        animator.SetTrigger("Attack");

        Collider[] hitEnemy = Physics.OverlapSphere(attackPoint.position, attackRange);

        foreach (Collider enemy in hitEnemy)
        {
            if (enemy.gameObject.CompareTag("Player"))
                enemy.gameObject.GetComponent<Estados>().Daño(meleeDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
