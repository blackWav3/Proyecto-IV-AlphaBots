using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    //private CapsuleCollider meleeCollider;
    public float swordRate = 2f;
    public int swordDamage = 1;
    float nextAtttackTime = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //meleeCollider = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextAtttackTime)
        {
            Attack();
        }
    }
    void Attack()
    {
        nextAtttackTime = Time.time + swordRate;
        animator.SetTrigger("Attack");
        //meleeCollider.isTrigger = true;
        //Invoke("DisableMeleeCollider", 0.5f);
        Collider[] hitEnemy = Physics.OverlapSphere(attackPoint.position, attackRange);

        foreach (Collider enemy in hitEnemy)
        {
            if (enemy.gameObject.CompareTag("Player"))
                enemy.gameObject.GetComponent<Estados>().Daño(swordDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    /*void DisableMeleeCollider()
    {
        meleeCollider.isTrigger = false;
    }*/
}
