using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spawner<PlayableCharacter>
{
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
    }

    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.W) ||
             Input.GetKey(KeyCode.A) ||
             Input.GetKey(KeyCode.S) ||
             Input.GetKey(KeyCode.D)) && IsActiveCharacterSet())
        {
            activeCharacter.Movement();
        }
    }

    private bool IsActiveCharacterSet()
    {
        if (activeCharacter == null)
        {
            Debug.LogError("Active Character Not Set.");
            return false;
        }
        return true;
    }
}
