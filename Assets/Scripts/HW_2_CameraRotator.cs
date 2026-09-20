using UnityEngine;

public class HW_2_CameraRotator : MonoBehaviour
{
    public int speed = 25;
    public float distance = 10f;
    private float yaw = 45f;
    private float pitch = 30f;
    private Vector3 center = new Vector3(0,0,0);

    void Start()
    {
        transform.position = new Vector3(0,0,7);
        transform.LookAt(center);
    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.mouseScrollDelta.y;
        if (scrollInput > 0f)
        {
            distance += 0.4f;
        }
        else if (scrollInput < 0f)
        {
            distance -= 0.4f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            pitch += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pitch -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            yaw += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            yaw -= speed * Time.deltaTime;
        }

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        transform.position = center + (rotation * new Vector3(0,0,distance));
        transform.rotation = rotation;
    }
}
