using UnityEngine;

/// <summary>
/// Abstract class for traps.
/// This class defines the common functionality and properties for all traps.
/// </summary>
public abstract class Trap : MonoBehaviour ,IDamagable
{
    protected int durability = 50;
    protected int damage = 20;
    protected LayerMask whatIDamage;

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
        Destroy(gameObject);
    }
}
