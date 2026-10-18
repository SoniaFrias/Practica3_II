using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject target;
    public Notifier notifier;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        notifier.OnCubeCollision += myResponse;
    }

    void myResponse()
    {
        Vector3 direccion = target.transform.position - rb.position;
        direccion.y = 0;
        rb.MoveRotation(Quaternion.LookRotation(direccion));
    }
}
