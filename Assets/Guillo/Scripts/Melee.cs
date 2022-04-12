using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Melee : MonoBehaviour
{
    public Brazos brazos;
    public Animator animator;
    public Transform martilloAttackPoint;
    public Transform firstAttackPointE, secondAttackPointE, centerPointE;
    public Transform firstAttackPointS, secondAttackPointS, centerPointS;
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
                Collider[] hitEnemyE = Physics.OverlapCapsule(firstAttackPointE.position, secondAttackPointE.position, attackRange);

                if (hitEnemyE == null)
                    return;

                foreach (Collider enemy in hitEnemyE)
                {
                    if (enemy.gameObject.CompareTag("Player"))
                        enemy.gameObject.GetComponent<Estados>().Daño(meleeDamage);
                }
                return;
            case Brazos.Sierra:
                Collider[] hitEnemyS = Physics.OverlapCapsule(firstAttackPointS.position, secondAttackPointS.position, attackRange);

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
                DrawWireCapsule(centerPointE.position, martilloAttackPoint.rotation, 0.2f, 1f);
                return;
            case Brazos.Sierra:
                DrawWireCapsule(centerPointS.position, martilloAttackPoint.rotation, 0.2f, 1f);
                return;
        }
    }
    public static void DrawWireCapsule(Vector3 _pos, Quaternion _rot, float _radius, float _height, Color _color = default(Color))
    {
        if (_color != default(Color))
            Handles.color = _color;
        Matrix4x4 angleMatrix = Matrix4x4.TRS(_pos, _rot, Handles.matrix.lossyScale);
        using (new Handles.DrawingScope(angleMatrix))
        {
            var pointOffset = (_height - (_radius * 2)) / 2;

            //draw sideways
            Handles.DrawWireArc(Vector3.up * pointOffset, Vector3.left, Vector3.back, -180, _radius);
            Handles.DrawLine(new Vector3(0, pointOffset, -_radius), new Vector3(0, -pointOffset, -_radius));
            Handles.DrawLine(new Vector3(0, pointOffset, _radius), new Vector3(0, -pointOffset, _radius));
            Handles.DrawWireArc(Vector3.down * pointOffset, Vector3.left, Vector3.back, 180, _radius);
            //draw frontways
            Handles.DrawWireArc(Vector3.up * pointOffset, Vector3.back, Vector3.left, 180, _radius);
            Handles.DrawLine(new Vector3(-_radius, pointOffset, 0), new Vector3(-_radius, -pointOffset, 0));
            Handles.DrawLine(new Vector3(_radius, pointOffset, 0), new Vector3(_radius, -pointOffset, 0));
            Handles.DrawWireArc(Vector3.down * pointOffset, Vector3.back, Vector3.left, -180, _radius);
            //draw center
            Handles.DrawWireDisc(Vector3.up * pointOffset, Vector3.up, _radius);
            Handles.DrawWireDisc(Vector3.down * pointOffset, Vector3.up, _radius);

        }
    }
    public enum Brazos
    {
        Martillo = 0,
        Espada = 1,
        Sierra = 2,
    }
}
