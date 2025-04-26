using UnityEngine;
using Oculus.Interaction;

public class AlwaysGrabbable : MonoBehaviour
{
    private Grabbable grabbable;

    void Awake()
    {
        grabbable = GetComponent<Grabbable>();
        if (grabbable != null)
        {
            grabbable.MaxGrabPoints = -1; // unlimited
        }
    }
}
