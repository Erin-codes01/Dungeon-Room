using UnityEngine;

/// <summary>
/// Tracks player health and handles taking damage.
/// Setup:
/// 1. Add to Player.
/// 2. Set startingHealth in Inspector (e.g., 3).
/// 3. Enemies should call TakeDamage(1) when they hit the Player.
/// </summary>
public class PlayerHealthSimple : MonoBehaviour
{
    public int startingHealth = 3;
    private int currentHealth;

    private bool isDead = false;

    void Start()
    {
        currentHealth = startingHealth;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        UpdateUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth += amount;
        if (currentHealth > startingHealth)
            currentHealth = startingHealth;

        UpdateUI();
    }

    private void Die()
    {
        isDead = true;

        if (GameManagerSimple.Instance != null)
        {
            GameManagerSimple.Instance.Lose();
        }

        // Disable movement
        var move = GetComponent<PlayerMovementTopDownSimple>();
        if (move != null) move.enabled = false;

        // Stop physics movement (FIXED)
        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = Vector2.zero;
    }

    private void UpdateUI()
    {
        if (GameManagerSimple.Instance != null)
        {
            GameManagerSimple.Instance.SetHealth(currentHealth, startingHealth);
        }
    }
}