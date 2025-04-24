using UnityEngine;

public class CandleFloat : MonoBehaviour
{
    public float floatSpeed = 1f;            // Speed of bobbing
    public float floatAmount = 0.5f;         // Distance it moves up/down
    public float moveSpeed = 0.5f;           // Forward movement speed
    public float rotationSpeed = 20f;        // Optional: slow rotation
    public Transform player;          // Assign this manually in the Inspector

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        // If not manually assigned, try to find a capsule in the scene
        if (player == null)
        {
            GameObject found = GameObject.Find("OVRCameraRig");
            if (found != null)
            {
                player = found.transform;
            }
            else
            {
                Debug.LogWarning("OVRCameraRig not found. Please assign it manually.");
            }
        }
    }

    void Update()
    {
        // Up and down bobbing
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        Vector3 floatPos = new Vector3(transform.position.x, startPos.y + yOffset, transform.position.z);
        transform.position = floatPos;

        // Move toward player capsule
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        // Optional: rotate slowly
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
