using UnityEngine;

public class CandleSpawner : MonoBehaviour
{
    public GameObject candlePrefab;
    public GameObject dissolveEffectPrefab;
    public int candlesToSpawn = 2;
    public float spawnRadius = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<OVRHand>() != null) // <-- changed from Hand to OVRHand
        {
            if (dissolveEffectPrefab != null)
            {
                Instantiate(dissolveEffectPrefab, transform.position, Quaternion.identity);
            }

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

            Destroy(gameObject);
        }
    }
}
