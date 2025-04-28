using UnityEngine;

public class CandleFloat : MonoBehaviour
{
    [Header("Bobbing Settings")]
    public float minFloatSpeed = 0.8f;    // Slowest bobbing speed
    public float maxFloatSpeed = 1.2f;    // Fastest bobbing speed
    public float minFloatAmount = 0.3f;   // Smallest bobbing height
    public float maxFloatAmount = 0.7f;   // Tallest bobbing height

    [Header("Movement Settings")]
    public float minMoveSpeed = 0.3f;     // Slowest move toward player
    public float maxMoveSpeed = 1.5f;     // Fastest move toward player

    [Header("Rotation Settings")]
    public float minRotationSpeed = 10f;  // Slowest rotation
    public float maxRotationSpeed = 40f;  // Fastest rotation

    public Transform player;              // Player reference

    private float moveSpeed;
    private float floatSpeed;
    private float floatAmount;
    private float rotationSpeedX;
    private float rotationSpeedY;
    private float rotationSpeedZ;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        // If player not assigned manually, find OVRCameraRig automatically
        if (player == null)
        {
            GameObject found = GameObject.Find("OVRCameraRig");
            if (found != null)
            {
                player = found.transform;
            }
            else
            {
                Debug.LogWarning("CandleFloat: No player found!");
            }
        }

        // Randomize movement, bobbing, and rotation speeds
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        floatSpeed = Random.Range(minFloatSpeed, maxFloatSpeed);
        floatAmount = Random.Range(minFloatAmount, maxFloatAmount);
        rotationSpeedX = Random.Range(minRotationSpeed, maxRotationSpeed);
        rotationSpeedY = Random.Range(minRotationSpeed, maxRotationSpeed);
        rotationSpeedZ = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    void Update()
    {
        if (player == null) return;

        // Bobbing motion
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        Vector3 floatPos = new Vector3(transform.position.x, startPos.y + yOffset, transform.position.z);
        transform.position = floatPos;

        // Move toward player
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Rotate on all three axes
        transform.Rotate(
            rotationSpeedX * Time.deltaTime,
            rotationSpeedY * Time.deltaTime,
            rotationSpeedZ * Time.deltaTime
        );
    }
}
