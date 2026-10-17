using UnityEngine;

public class Humanoid1 : MonoBehaviour
{
    public GameObject target;
    public NotifierCube notifier;
    private bool isMoving = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        notifier.OnType1Collision += myResponse;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.MoveRotation(Quaternion.LookRotation(target.transform.position - rb.position));
            Vector3 direccion = target.transform.position - rb.position;
            direccion.y = 0;
            // Movimiento
            rb.MoveRotation(Quaternion.LookRotation(direccion));
            Vector3 delta = target.transform.position - rb.position;
            delta.y = 0;
            delta = delta.normalized;
            rb.MovePosition(rb.position + delta * 10 * Time.fixedDeltaTime);
        }
    }

    void myResponse() {
        isMoving = true; 
    }
}
