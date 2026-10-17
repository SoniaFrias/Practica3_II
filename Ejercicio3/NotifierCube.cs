using UnityEngine;

public class NotifierCube : MonoBehaviour
{
    public delegate void mensaje();
    public event mensaje OnType1Collision;
    public event mensaje OnType2Collision;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tipo 1"))
        {
            OnType1Collision();
        }
        if (other.gameObject.CompareTag("Tipo 2"))
        {
            OnType2Collision();
        }
    }
}