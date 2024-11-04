using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GingerCat : PlayableCharacter
{
    public Animator animator;
    public RuntimeAnimatorController animatorController;

    private void Awake()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
        // Assign the character's specific Animator Controller to the Animator
        animator.runtimeAnimatorController = animatorController;
    }



    public override void SpecialAbillity()
    {
        Trap trap = FindNearbyTrap();
        if (trap != null) 
        {
            if (trap is PottedPlant pottedPlant)
            {
                pottedPlant.TakeDamage(SpecialAttack);
            }
            else
            {
                ApplyDamage(trap);
                trap.ApplyDamageBack(this);
            }
        }
    }
}
