using UnityEngine;
using System.Collections;

public class PlayerCombat : Melee
{
    private void Start()
    {
        animator = GetComponent<Animator>();
        attackRange = 0.6f;
        fireRate = 1;
        meleeDamage = 20;
    }
}
