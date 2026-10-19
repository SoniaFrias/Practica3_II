using UnityEngine;

public class MoveRobot : MonoBehaviour
{
    public GameObject astronaut;
    private Rigidbody rb;
    private int speed;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 3;
    }

    void FixedUpdate()
    {
        Vector3 target = astronaut.transform.position - new Vector3(2f,2f,2f);
        Vector3 direction = target - rb.position;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.001f)
        {
            rb.MoveRotation(Quaternion.LookRotation(direction));
            Vector3 targetPosition = rb.position + direction.normalized * speed * Time.fixedDeltaTime;
            
            // Mantener la Y física intacta para no anular caídas ni saltos
            targetPosition.y = rb.position.y;
            rb.MovePosition(targetPosition);
        }
    }
}