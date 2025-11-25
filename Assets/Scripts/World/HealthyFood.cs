using UnityEngine;

public class HealthyFood : MonoBehaviour
{
    [SerializeField] float healthBoost = 15f;
    [SerializeField] float energyBoost = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats stats = other.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.AddHealth(healthBoost);
            stats.AddEnergy(energyBoost);
            Destroy(gameObject);
        }
    }
}
