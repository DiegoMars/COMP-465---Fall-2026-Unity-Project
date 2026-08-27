using UnityEngine;

public class MyFirstTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Transform name is a powerful thing to use
        Debug.Log($"Hello World! from {transform.name}");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Hello World! from {transform.name}");
    }
}
