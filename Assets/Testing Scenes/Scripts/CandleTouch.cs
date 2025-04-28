using UnityEngine;
using System.Collections;
using INab.Dissolve;


public class CandleTouch : MonoBehaviour
{
    private CandleDissolveTrigger dissolveTrigger;
    private CandleSpawner candleSpawner;
    private bool isDissolving = false;

    private void Start()
    {
        dissolveTrigger = GetComponent<CandleDissolveTrigger>();
        candleSpawner = GetComponent<CandleSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDissolving && other.CompareTag("Player"))
        {
            if (dissolveTrigger != null)
            {
                isDissolving = true;
                dissolveTrigger.TriggerDissolve(); // <- Call your special candle dissolve animation!
                StartCoroutine(DissolveAndSpawn());
            }
        }
    }

    private IEnumerator DissolveAndSpawn()
    {
        yield return new WaitForSeconds(2f); // Match your dissolve time here

        if (candleSpawner != null)
        {
            candleSpawner.SpawnCandles();
        }

        Destroy(gameObject);
    }
}
