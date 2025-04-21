using UnityEngine;

public class CandleTouch : MonoBehaviour
{
    public GameObject dissolveEffectPrefab;  // Drag your particle prefab here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // make sure PlayerCapsule is tagged "Player"
        {
            // Instantiate particle effect at candle position
            if (dissolveEffectPrefab != null)
            {
                Instantiate(dissolveEffectPrefab, transform.position, Quaternion.identity);
            }

            // Destroy the candle
            Destroy(gameObject);
        }
    }
}
