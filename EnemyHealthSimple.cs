using UnityEngine;

public class EnemyHealthSimple : MonoBehaviour
{
    public int health = 3;

    private void Start()
    {
        if (GameManagerSimple.Instance != null)
        {
            GameManagerSimple.Instance.RegisterEnemy();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (GameManagerSimple.Instance != null)
        {
            GameManagerSimple.Instance.EnemyKilled();
        }

        Destroy(gameObject);
    }
}