using UnityEngine;

/// <summary>
/// Interface for objects that can take damage and die.
/// </summary>
public interface IDamagable
{
    /// <summary>
    /// Applies the specified amount of damage to this object and checks if it should die.
    /// </summary>
    /// <param name="damagePoints">The amount of damage this object receives.</param>
    void TakeDamage(int damagePoints);

    /// <summary>
    /// Handles the actions taken when this object dies.
    /// </summary>
    void Die();
}
