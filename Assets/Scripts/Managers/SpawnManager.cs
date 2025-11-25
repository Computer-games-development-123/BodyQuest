using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject healthyFoodPrefab;
    [SerializeField] GameObject junkFoodPrefab;
    [SerializeField] GameObject virusPrefab;

    [Header("Spawn Area")]
    [SerializeField] Vector2 minPosition;
    [SerializeField] Vector2 maxPosition;

    [Header("Timing")]
    [SerializeField] float spawnInterval = 3f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        float x = Random.Range(minPosition.x, maxPosition.x);
        float y = Random.Range(minPosition.y, maxPosition.y);
        Vector2 pos = new Vector2(x, y);

        float roll = Random.value;

        GameObject prefabToSpawn;

        if (roll < 0.5f)
            prefabToSpawn = healthyFoodPrefab;
        else if (roll < 0.8f)
            prefabToSpawn = junkFoodPrefab;
        else
            prefabToSpawn = virusPrefab;

        Instantiate(prefabToSpawn, pos, Quaternion.identity);
    }
}
