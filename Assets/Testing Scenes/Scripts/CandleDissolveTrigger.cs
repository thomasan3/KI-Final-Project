using UnityEngine;
using INab.Dissolve; // Include the namespace for Dissolver

public class CandleDissolveTrigger : MonoBehaviour
{
    private Dissolver dissolver;
    private bool hasTriggered = false;

    void Start()
    {
        dissolver = GetComponent<Dissolver>();

        if (dissolver == null)
        {
            Debug.LogWarning("No Dissolver component found on " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            if (dissolver != null)
            {
                dissolver.Dissolve();
            }

            // Optional: destroy the object after dissolve finishes
            Destroy(gameObject, dissolver.duration + 0.1f);
        }
    }
}
