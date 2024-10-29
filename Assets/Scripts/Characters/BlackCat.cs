using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCat : PlayableCharacter
{
    public override void SpecialAbillity()
    {
        Trap trap = FindNearbyTrap();
        if (trap != null)
        {
            if (trap is Roomba roomba)
            {
                roomba.TakeDamage(SpecialAttack);
            }
            else
            {
                ApplyDamage(trap);
                trap.ApplyDamageBack(this);
            }
        }
    }
}
