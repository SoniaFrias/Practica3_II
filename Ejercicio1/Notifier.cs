using UnityEngine;

public class Notifier : MonoBehaviour
{
    public delegate void menssage();
    public event menssage OnCubeCollision;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")
        {
            Debug.Log("Oh oh");
            OnCubeCollision();
        }
    }
}
