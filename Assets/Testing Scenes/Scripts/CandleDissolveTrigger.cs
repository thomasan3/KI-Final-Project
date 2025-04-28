using UnityEngine;
using INab.Dissolve;

public class CandleDissolveTrigger : MonoBehaviour
{
    private Dissolver dissolver;
    private bool hasTriggered = false;

    private void Start()
    {
        dissolver = GetComponent<Dissolver>();

        if (dissolver == null)
        {
            Debug.LogWarning("No Dissolver component found on " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player")) // or if (other.GetComponent<OVRHand>() != null) for hand check
        {
            hasTriggered = true;

            if (dissolver != null)
            {
                dissolver.Dissolve();
                Destroy(gameObject, dissolver.duration + 0.1f); // Auto-destroy after dissolve finishes
            }
            else
            {
                Destroy(gameObject); // Just destroy immediately
            }
        }
    }
}
