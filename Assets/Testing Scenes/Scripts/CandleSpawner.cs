using UnityEngine;

public class CandleSpawner : MonoBehaviour
{
    public GameObject candlePrefab; // assign your floating candle prefab here
    public GameObject dissolveEffectPrefab;

    public int candlesToSpawn = 2; // how many to spawn on touch
    public float spawnRadius = 2f; // distance from the original candle

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Spawn particle effect
            if (dissolveEffectPrefab != null)
            {
                Instantiate(dissolveEffectPrefab, transform.position, Quaternion.identity);
            }

            // Spawn new candles
            for (int i = 0; i < candlesToSpawn; i++)
            {
                Vector3 offset = new Vector3(
                    Random.Range(-spawnRadius, spawnRadius),
                    Random.Range(0.5f, 1.5f),  // little Y height variation
                    Random.Range(-spawnRadius, spawnRadius)
                );

                Vector3 spawnPosition = transform.position + offset;
                Instantiate(candlePrefab, spawnPosition, Quaternion.identity);
            }

            // Destroy this candle
            Destroy(gameObject);
        }
    }
}
