using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        float positionX = Random.Range(-24, 5);
        float positionZ = Random.Range(1, 20);
        rb.MovePosition(new Vector3(positionX, rb.position.y, positionZ));
    }
}
