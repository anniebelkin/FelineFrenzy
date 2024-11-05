using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Spawner<PlayableCharacter>
{
    public Animator animator;
    public LayerMask trapsLayer;

    public AudioClip gameOverSound;
    public AudioSource audioSource;

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
            ChangeToNextCharacter();

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

    private void ChangeToNextCharacter() 
    {
        int numOfCharacters = spawnables.Count;
        for (int i = 0; i < numOfCharacters; i++)
        {
            PlayableCharacter next= GetNextSpawnable();
            if (!next.IsDead())
            {
                Swap(next);
                return;
            }
        }
        RestartGame();
    }

    private void RestartGame()
    {
        if (audioSource != null && gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }

        Debug.Log("All characters are dead! Restarting the game...");

        // Reload the current scene
        Invoke("ReloadScene", 3f);
    }

    private void ReloadScene()
    {
        // Reload the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}