using UnityEngine;

public class JunkFood : MonoBehaviour
{
    [SerializeField] float energyBoost = 20f;
    [SerializeField] float healthPenalty = 5f;
    [SerializeField] float moodPenalty = 8f;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats stats = other.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.AddEnergy(energyBoost);
            stats.AddHealth(-healthPenalty);
            stats.AddMood(-moodPenalty);
            Destroy(gameObject);
        }
    }
}
