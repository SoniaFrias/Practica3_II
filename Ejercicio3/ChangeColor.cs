using UnityEngine;

public class changeColor : MonoBehaviour
{
    private Renderer[] renderers;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Cube")
        {
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        Color colorAleatorio = new Color(Random.value, Random.value, Random.value);
        foreach (Renderer r in renderers)
        {
            foreach (Material mat in r.materials)
            {
                mat.color = colorAleatorio;
            }
        }
    }
}