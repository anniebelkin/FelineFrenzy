using UnityEngine;

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

    public void ApplyDamage(IDamagable damagable)
    {
        damagable.TakeDamage(damage);
    }

    public void TakeDamage(int damagePoints)
    {
        durability = Mathf.Max(0, durability - damagePoints);

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
