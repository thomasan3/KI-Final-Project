using UnityEngine;

public class CandleFloat : MonoBehaviour
{
    public float floatSpeed = 1f;            // Speed of bobbing
    public float floatAmount = 0.5f;         // Distance it moves up/down
    public float moveSpeed = 16.0f;           // Forward movement speed
    public float rotationSpeed = 20f;        // Optional: slow rotation
    public Transform playerCapsule;          // Assign this manually in the Inspector

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        // If not manually assigned, try to find a capsule in the scene
        if (playerCapsule == null)
        {
            GameObject found = GameObject.Find("PlayerCapsule");
            if (found != null)
            {
                playerCapsule = found.transform;
            }
            else
            {
                Debug.LogWarning("PlayerCapsule not found. Please assign it manually.");
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
        if (playerCapsule != null)
        {
            Vector3 direction = (playerCapsule.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        // Optional: rotate slowly
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
