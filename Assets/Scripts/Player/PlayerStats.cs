using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Max Values")]
    public float maxHealth = 100f;
    public float maxEnergy = 100f;
    public float maxMood = 100f;

    [Header("Current Values")]
    public float health;
    public float energy;
    public float mood;

    void Start()
    {
        health = maxHealth;
        energy = maxEnergy * 0.7f; // לדוגמה מתחילים ב-70%
        mood = maxMood * 0.8f;   // 80%
    }

    public void AddHealth(float amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
    }

    public void AddEnergy(float amount)
    {
        energy = Mathf.Clamp(energy + amount, 0, maxEnergy);
    }

    public void AddMood(float amount)
    {
        mood = Mathf.Clamp(mood + amount, 0, maxMood);
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
