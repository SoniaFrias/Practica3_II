using UnityEngine;

public class MoveAstronaut : MonoBehaviour
{
    public delegate void message(int score); 
    public event message OnRockFound;
    private Rigidbody rb;
    private int speed;
    private int score;
    private bool jumpRequested;
    private bool isJumping;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 5;
        score = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            jumpRequested = true;
            isJumping = true; 
        }
    } 

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 horizontalDir = new Vector3(x, 0f, z).normalized;

        if (horizontalDir.sqrMagnitude > 0.001f)
        {
            rb.MoveRotation(Quaternion.LookRotation(horizontalDir));

            Vector3 delta = horizontalDir * speed * Time.fixedDeltaTime;
            Vector3 targetPosition = rb.position + delta;
            
            // Mantener la Y física intacta para no anular caídas ni saltos
            targetPosition.y = rb.position.y;
            rb.MovePosition(targetPosition);
        }

        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            jumpRequested = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            isJumping = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            score += 5;
            OnRockFound(score);
        }
    }
}
