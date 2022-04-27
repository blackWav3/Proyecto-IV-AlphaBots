using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Melee : MonoBehaviour
{
    public Brazos brazos;
    public Animator animator;
    public Transform martilloAttackPoint, espadaAttackPoint, sierraAttackPoint;
    public float attackRange;
    public float fireRate;
    public int meleeDamage;
    float nextAtttackTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            brazos = Brazos.Martillo;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            brazos = Brazos.Espada;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            brazos = Brazos.Sierra;

        if (Input.GetButton("Fire1") && Time.time > nextAtttackTime)
        {
            Attack();
        }
    }
    void Attack()
    {
        nextAtttackTime = Time.time + fireRate;
        animator.SetTrigger("Attack");

        switch (brazos)
        {
            case Brazos.Martillo:
                Collider[] hitEnemyM = Physics.OverlapSphere(martilloAttackPoint.position, attackRange);

                if (hitEnemyM == null)
                    return;

                foreach (Collider enemy in hitEnemyM)
                {
                    if (enemy.gameObject.CompareTag("Player"))
                        enemy.gameObject.GetComponent<Estados>().Daño(meleeDamage);
                }
                return;

            case Brazos.Espada:
                Collider[] hitEnemyE = Physics.OverlapSphere(espadaAttackPoint.position, attackRange);

                if (hitEnemyE == null)
                    return;

                foreach (Collider enemy in hitEnemyE)
                {
                    if (enemy.gameObject.CompareTag("Player"))
                        enemy.gameObject.GetComponent<Estados>().Daño(meleeDamage);
                }
                return;

            case Brazos.Sierra:
                Collider[] hitEnemyS = Physics.OverlapSphere(sierraAttackPoint.position, attackRange);

                if (hitEnemyS == null)
                    return;

                foreach (Collider enemy in hitEnemyS)
                {
                    if (enemy.gameObject.CompareTag("Player"))
                        enemy.gameObject.GetComponent<Estados>().Daño(meleeDamage);
                }
                return;
            default:
                return;
        }
    }
    private void OnDrawGizmosSelected()
    {
        switch (brazos)
        {
            case Brazos.Martillo:
                if (martilloAttackPoint == null)
                    return;
                Gizmos.DrawWireSphere(martilloAttackPoint.position, attackRange);
                return;

            case Brazos.Espada:
                if (espadaAttackPoint == null)
                    return;
                Gizmos.DrawWireSphere(espadaAttackPoint.position, attackRange);
                return;

            case Brazos.Sierra:
                if (sierraAttackPoint == null)
                    return;
                Gizmos.DrawWireSphere(sierraAttackPoint.position, attackRange);
                return;

            default:
                return;
        }        
    }
    public enum Brazos
    {
        Martillo = 0,
        Espada = 1,
        Sierra = 2,
    }
}
