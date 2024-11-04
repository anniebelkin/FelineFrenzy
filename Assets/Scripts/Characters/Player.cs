using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spawner<PlayableCharacter>
{
    public Animator animator;
    private bool isMoving;
    public LayerMask trapsLayer;
    public Vector2 input; // Store movement direction
    public List<PlayableCharacter> characters; // List of available characters
    private PlayableCharacter currentCharacter; // Currently activ

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
            if (!isMoving)
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");

                Debug.Log("this is input.x" + input.x);
                Debug.Log("this is input.y" + input.y);


                if (input.x != 0) input.y = 0;
               


                if (input != Vector2.zero)
                {
                    // Move the character
                    activeCharacter.Movement();

                    animator.SetFloat("moveX", input.x);
                    animator.SetFloat("moveY", input.y);

                    var targetPos = transform.position;
                    targetPos.x = input.x;
                    targetPos.y = input.y; 
                }
                else
                {
                    animator.SetBool("IsMoving", false);
                }
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