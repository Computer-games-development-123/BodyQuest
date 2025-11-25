using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    [Header("UI Bars")]
    [SerializeField] Slider healthBar;
    [SerializeField] Slider energyBar;
    [SerializeField] Slider moodBar;

    void Start()
    {
        if (playerStats == null)
        {
            playerStats = FindFirstObjectByType<PlayerStats>();
        }

        healthBar.maxValue = playerStats.maxHealth;
        energyBar.maxValue = playerStats.maxEnergy;
        moodBar.maxValue = playerStats.maxMood;
    }

    void Update()
    {
        healthBar.value = playerStats.health;
        energyBar.value = playerStats.energy;
        moodBar.value = playerStats.mood;
    }
}
