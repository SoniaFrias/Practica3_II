using UnityEngine;

public class Chaser : MonoBehaviour
{
    public delegate void message(Vector3 target);
    public delegate void message2();
    public event message OnAstronautDetected;
    public event message2 OnAstronautFound;


    private Rigidbody rb;
    public Vector3 target;
    private int speed;
    private bool found;

    public Chaser[] notifiers;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        found = false;
        speed = 4;
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        notifiers = new Chaser[enemyObjects.Length];

        for (int i = 0; i < enemyObjects.Length; i++)
        {
            notifiers[i] = enemyObjects[i].GetComponent<Chaser>();
            if (notifiers[i] != this)
            {
                notifiers[i].OnAstronautDetected += chase;
            }
        }
    }

    void FixedUpdate()
    {
        if (found)
        {
            Vector3 direction = target - rb.position;

            if (direction.sqrMagnitude > 0.001f)
            {
                rb.MoveRotation(Quaternion.LookRotation(direction));
                Vector3 delta = direction.normalized * speed * Time.fixedDeltaTime;
                Vector3 targetPosition = rb.position + delta;
                rb.MovePosition(targetPosition);
            } else
            {
                found = false;
            }
        }
    }

    void chase(Vector3 position)
    {
        found = true;
        target = position;
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Astronaut")
        {
            found = true;
            target = collision.gameObject.transform.position;
            OnAstronautDetected(collision.gameObject.transform.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Astronaut")
        {
            OnAstronautFound();
        }
    }
}