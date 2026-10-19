using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Rigidbody rb;
    private int rangeXMin = -38;
    private int rangeXMax = 40;
    private int rangeZMin = -28;
    private int rangeZMax = 40;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        float positionX = Random.Range(rangeXMin, rangeXMax);
        float positionZ = Random.Range(rangeZMin, rangeZMax);
        rb.MovePosition(new Vector3(positionX, rb.position.y, positionZ));
    }
}
