using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract class for traps.
/// This class defines the common functionality and properties for all traps.
/// </summary>
public abstract class Trap : MonoBehaviour ,IDamagable
{
    protected int durability = 50;
    protected int damage = 20;
    public LayerMask whatIDamage;
    public Sprite destroyedSprite;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public void ApplyDamage(IDamagable damagable)
    {
        damagable.TakeDamage(damage);
    }

    public void TakeDamage(int damagePoints)
    {
        durability = Mathf.Max(0, durability - damagePoints);

        if (spriteRenderer != null)
        {
            StartCoroutine(FlashCoroutine());
        }

        if (durability == 0)
        {
            Die();
        }

    }

    public virtual void Die()
    {
        GetComponent<SpriteRenderer>().sprite = destroyedSprite;
        GetComponent<Collider2D>().enabled = false;
    }

    public void ApplyDamageBack(IDamagable damagable)
    {
        damagable.TakeDamage(damage / 2);
    }

    private void Awake()
    {
        // Cache the SpriteRenderer and store the original color
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    private IEnumerator FlashCoroutine()
    {
        spriteRenderer.color = Color.red;  // Change color to indicate damage
        yield return new WaitForSeconds(0.1f);  // Wait briefly
        spriteRenderer.color = originalColor;  // Restore original color
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & whatIDamage) != 0)
        {
            IDamagable damagable = collision.collider.GetComponent<IDamagable>();
            if (damagable != null)
            {
                ApplyDamage(damagable);
            }
        }
    }
}
