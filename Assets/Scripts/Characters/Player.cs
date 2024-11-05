using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spawner<PlayableCharacter>
{
    public Animator animator;
    private bool isMoving;
    public LayerMask trapsLayer;
    public Vector2 input; // Store movement direction

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private PlayableCharacter activeCharacter
    {
        get { return currentSpawnable; }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeToNextSpawnable();
        }
        if (Input.GetKeyDown(KeyCode.E) && IsActiveCharacterSet())
        {
            activeCharacter.SpecialAbillity();
        }
    }


    void FixedUpdate()
    {
        if (IsActiveCharacterSet())
        {
            if ((Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D)))
            {
                activeCharacter.Movement();
            }
            else 
            {
                activeCharacter.Idle();
            }
        }
    }

    private bool IsActiveCharacterSet()
    {
        if (activeCharacter == null)
        {
            Debug.LogError("Active Character Not Set.");
            return false;
        }
        return !activeCharacter.IsDead();
    }
}