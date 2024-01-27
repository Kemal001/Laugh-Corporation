using UnityEngine;

public class VacuumCleaner : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 200.0f;
    public float squareSize = 10.0f;

    private float minX, maxX, minZ, maxZ;

    void Start()
    {
        minX = transform.position.x - squareSize / 2;
        maxX = transform.position.x + squareSize / 2;
        minZ = transform.position.z - squareSize / 2;
        maxZ = transform.position.z + squareSize / 2;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (transform.position.x < minX || transform.position.x > maxX ||
            transform.position.z < minZ || transform.position.z > maxZ)
        {
            RandomlyChangeDirection();
        }
    }

    void RandomlyChangeDirection()
    {
        float turnAngle = Random.Range(-90, 90);
        transform.Rotate(Vector3.up, turnAngle);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            Mathf.Clamp(transform.position.z, minZ, maxZ)
        );
    }
}
