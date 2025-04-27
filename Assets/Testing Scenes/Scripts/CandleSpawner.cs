using UnityEngine;

public class CandleSpawner : MonoBehaviour
{
    public GameObject candlePrefab;             // Prefab to spawn (should have CandleFloat + CandleTouch)
    public GameObject dissolveEffectPrefab;     // Particles prefab
    public int candlesToSpawn = 2;               // How many to spawn
    public float spawnRadius = 2f;               // Spawn range around original

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // check if it's player touching
        {
            // Play dissolve particle effect
            if (dissolveEffectPrefab != null)
            {
                GameObject effect = Instantiate(dissolveEffectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 3f); // Auto-destroy particles
            }

            // Spawn new candles
            for (int i = 0; i < candlesToSpawn; i++)
            {
                Vector3 offset = new Vector3(
                    Random.Range(-spawnRadius, spawnRadius),
                    Random.Range(0.5f, 1.5f),
                    Random.Range(-spawnRadius, spawnRadius)
                );

                Vector3 spawnPosition = transform.position + offset;
                Instantiate(candlePrefab, spawnPosition, Quaternion.identity);
            }

            // Destroy this candle after spawning
            Destroy(gameObject);
        }
    }
}
