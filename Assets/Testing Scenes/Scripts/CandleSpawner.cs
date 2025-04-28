using UnityEngine;

public class CandleSpawner : MonoBehaviour
{
    public GameObject candlePrefab;
    public GameObject dissolveEffectPrefab;
    public int candlesToSpawn = 2;
    public float spawnRadius = 6f;
    private Transform player; // make it private

    private void Start()
    {
        // Try to find the player object automatically at runtime
        GameObject playerObject = GameObject.Find("ArmatureSkinningUpdateRetarget"); // <- exact name in Hierarchy
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("CandleSpawner could not find player (ArmatureSkinningUpdateRetarget)!");
        }
    }

    public void SpawnCandles()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference still missing, can't spawn candles!");
            return;
        }

        // Play dissolve particle effect
        if (dissolveEffectPrefab != null)
        {
            GameObject effect = Instantiate(dissolveEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 3f);
        }

        // Spawn new candles around the PLAYER
        for (int i = 0; i < candlesToSpawn; i++)
        {
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(
                player.position.x + randomCircle.x,
                player.position.y + Random.Range(0.5f, 1.5f),
                player.position.z + randomCircle.y
            );

            Instantiate(candlePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
