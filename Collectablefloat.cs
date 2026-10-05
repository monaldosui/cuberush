using UnityEngine;

public class Collectiblefloat : MonoBehaviour
{
    public float floatHeight = 0.25f;
    public float floatSpeed = 2f;
    public float rotationSpeed = 30f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Floating up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = new Vector3(
            startPosition.x,
            newY,
            startPosition.z
        );

        // Slow rotation
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}