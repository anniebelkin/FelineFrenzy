using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic; // Assign your AudioSource in the Inspector

    private void Awake()
    {
        // Check if there's already an instance of AudioManager
        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject); // Destroy duplicate
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Make this instance persistent
        }
    }

    private void Start()
    {
        // Play background music if it's not already playing
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }
}
