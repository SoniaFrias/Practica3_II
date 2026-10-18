using UnityEngine;

public class Humanoid1 : MonoBehaviour
{
    public GameObject targetType1;
    public GameObject targetType2;
    public NotifierCube notifier;
    private bool moving1 = false;
    private bool moving2 = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        notifier.OnType1Collision += myResponse1;
        notifier.OnType2Collision += myResponse2;
    }

    void FixedUpdate()
    {
        if (moving1)
        {
            MovingTowardsShield(targetType1.transform);
        }
        if (moving2)
        {
            MovingTowardsShield(targetType2.transform);
        }
    }

    void MovingTowardsShield(Transform t)
    {
        Vector3 direccion = t.position - rb.position;
        direccion.y = 0;
        // Movimiento
        rb.MoveRotation(Quaternion.LookRotation(direccion));
        Vector3 delta = direccion.normalized;
        rb.MovePosition(rb.position + delta * 10 * Time.fixedDeltaTime);
    }

    void myResponse1() {
        moving1 = true; 
        moving2 = false;
    }

    void myResponse2()
    {
        moving2 = true; 
        moving1 = false;
    }
}
