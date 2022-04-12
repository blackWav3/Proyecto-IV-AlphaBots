using UnityEngine;
using System.Collections;

public class PlayerCombat : Melee
{
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (brazos == Brazos.Martillo)
        {
            attackRange = 0.38f;
            fireRate = 1;
            meleeDamage = 5;
            transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
        }
        if (brazos == Brazos.Espada)
        {
            attackRange = 0.2f;
            fireRate = 3;
            meleeDamage = 10;
            transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
        }
        if (brazos == Brazos.Sierra)
        {
            attackRange = 0.2f;
            fireRate = 1;
            meleeDamage = 20;
            transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
        }
    }
}
