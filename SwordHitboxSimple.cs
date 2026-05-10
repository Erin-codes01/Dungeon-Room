using UnityEngine;

public class SwordHitboxSimple : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        // SCORE
        if (GameManagerSimple.Instance != null)
        {
            GameManagerSimple.Instance.AddScore(1);
        }

        // ENEMY HEALTH (IMPORTANT)
        EnemyHealthSimple enemy = other.GetComponent<EnemyHealthSimple>();

        if (enemy != null)
        {
            enemy.TakeDamage(999); // guaranteed kill
        }
        else
        {
            Destroy(other.gameObject);

            if (GameManagerSimple.Instance != null)
            {
                GameManagerSimple.Instance.EnemyKilled();
            }
        }
    }
}