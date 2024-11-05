using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected List<T> spawnables;
    protected T currentSpawnable;
    private int currentIndex = 0;
    
    public void Start()
    {
        if (!IsListEmpty())
        {
            HideSpawner();
            currentIndex = Random.Range(0, spawnables.Count);
            Swap(spawnables[currentIndex]);
        }
    }

    protected T GetNextSpawnable()
    {
        if (!IsListEmpty())
        {
            currentIndex = (currentIndex + 1) % spawnables.Count;
            return spawnables[currentIndex];
        }
        return null;
    }

    protected void Swap(T nextSpawnable)
    {
        if (currentSpawnable != null)
        {
            currentSpawnable.gameObject.SetActive(false);
        }
        currentSpawnable = nextSpawnable;
        currentSpawnable.gameObject.SetActive(true);
    }
    
    private void HideSpawner() 
    {
        // hides the spawn point logo if exists
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        foreach (T spawnable in spawnables)
        {
            if (spawnable != null)
            {
                spawnable.gameObject.SetActive(false);
            }
        }
    }

    private bool IsListEmpty()
    {
        if (spawnables == null || spawnables.Count == 0)
        {
            Debug.LogWarning("No spawnables assigned to the Spawner.");
            return true;
        }
        return false;
    }
}
