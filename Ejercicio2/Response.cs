using UnityEngine;

public class Response : MonoBehaviour
{
    public GameObject target;
    public Notifier notifier;
    private bool isMoving = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        notifier.OnCubeCollision += myResponse;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 direccion = t.position - rb.position;
            direccion.y = 0;
            // Movimiento
            rb.MoveRotation(Quaternion.LookRotation(direccion));
            Vector3 delta = direccion.normalized;
            rb.MovePosition(rb.position + delta * 10 * Time.fixedDeltaTime);
        }
    }

    void myResponse() {
        isMoving = true; 
    }
}
