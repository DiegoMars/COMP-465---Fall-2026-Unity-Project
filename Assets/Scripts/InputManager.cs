using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int speed = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            speed += 1;
            if (speed > 20)
            {
                speed = 20;
            }
            Debug.Log($"Speed: {speed}");
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            speed -= 1;
            if (speed < 0)
            {
                speed = 0;
            }
            Debug.Log($"Speed: {speed}");
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(new Vector3(1, 0, 0), speed * 100 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Y))
        {
            transform.Rotate(new Vector3(0, 1, 0), speed * 100 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(new Vector3(0, 0, 1), speed * 100 * Time.deltaTime);
        }
    }
}
