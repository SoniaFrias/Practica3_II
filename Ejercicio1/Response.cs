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
            Vector3 position = Vector3.MoveTowards(
                rb.position, 
                target.transform.position, 
                Time.fixedDeltaTime
            );

            rb.MovePosition(position);
        }
    }

    void myResponse() {
        isMoving = true; 
    }
}
