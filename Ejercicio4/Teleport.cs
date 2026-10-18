using UnityEngine;

public class Teleport : MonoBehaviour
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
        rb.MovePosition(target.transform.position);   
    }
}
