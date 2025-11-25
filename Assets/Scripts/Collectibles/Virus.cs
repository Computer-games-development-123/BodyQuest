using UnityEngine;

public class Virus : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] float moodPenalty = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats stats = other.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.AddHealth(-damage);
            stats.AddMood(-moodPenalty);
            Destroy(gameObject);
        }
    }
}
