using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCat : PlayableCharacter
{

    public override void SpecialAbillity()
    {
        AttackSound();
        Trap trap = FindNearbyTrap();
        if (trap != null)
        {
            if (trap is Snack snack)
            {
                snack.TakeDamage(SpecialAttack);
            }
            else
            {
                ApplyDamage(trap);
                trap.ApplyDamageBack(this);
            }
        }
    }
}
