using UnityEngine;
using System.Collections;
using INab.Dissolve;

public class CandleDissolveTrigger : MonoBehaviour
{
    private Dissolver dissolver;

    private void Start()
    {
        dissolver = GetComponent<Dissolver>();
    }

    public void TriggerDissolve()
    {
        if (dissolver != null)
        {
            dissolver.Dissolve();
        }
    }
}
