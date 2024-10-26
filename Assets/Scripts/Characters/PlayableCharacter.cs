using UnityEngine;

/// <summary>
/// Abstract class for playable characters in the game.
/// </summary>
public abstract class PlayableCharacter : MonoBehaviour, IDamagable
{
    [SerializeField, Tooltip("Speed of the character.")]
    protected int moveSpeed;

    protected int basicAttack = 10;
    protected int SpecialAttack = 50;

    protected int maxHp = 50;
    protected int currentHp;

    private Rigidbody2D playerRb;

    void Start()
    {
        playerRb = GetComponentInParent<Rigidbody2D>();
        currentHp = maxHp;
    }
    public void TakeDamage(int damagePoints)
    {
        currentHp = Mathf.Max(0, currentHp - damagePoints); ;
        if (currentHp == 0) 
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Movement()
    {
        if (IsPlayerRbSet())
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 direction = new Vector2(moveHorizontal, moveVertical).normalized;
            playerRb.MovePosition(playerRb.position + direction * moveSpeed * Time.deltaTime);
        }
    }

    protected abstract void SpecialAbillity();

    protected void ApplyDamage(IDamagable damagable) 
    {
        damagable.TakeDamage(basicAttack);
    }

    private bool IsPlayerRbSet()
    {
        if (playerRb == null)
        {
            Debug.LogError("Player Rigid Body Not Set.");
            return false;
        }
        return true;
    }
}
