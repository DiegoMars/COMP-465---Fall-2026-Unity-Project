using UnityEngine;
using UnityEngine.UI;

public class MyFirstTest : MonoBehaviour
{

    public GameObject CubePrefab;

    public int direction = 1;

    RaycastHit hitInfo;

    private void OnEnable()
    {
        // Is is how C# manages if something is in "context" or something like that
        // UIManager.OnChangeGeometry += UIManagerOnOnChangeGeometry;
    }

    private void OnDisable()
    {
        // UIManager.OnChangeGeometry -= UIManagerOnOnChangeGeometry;
    }

    private void UIManagerOnOnChangeGeometry(Button button)
    {
        // you prefrom logic here
        Debug.Log($"You selected {button.name}");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Transform name is a powerful thing to use
        Debug.Log($"Hello World! from {transform.name}");
        direction = 1;
    }

    // Update is called once per frame
    // Works differently on different machines, depending on hardware
    void Update()
    {
        // 0 would be left click
        if (Input.GetMouseButtonDown(0))
        {
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                // do some logic here that indicates you have collided with an object
                Debug.Log($"We collided with something ... {hitInfo.transform.name}");
                //
                // there are many different PrimitiveType things that can be instantiated
                var goCube = GameObject.Instantiate(CubePrefab);

                // This lil transform changes so that it moves the cube up out of the plane
                // But this does not account for pressing, for example, on the side of another cube
                // goCube.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y+0.5f, hitInfo.point.z);

                if (hitInfo.transform.tag == "Base")
                {
                    goCube.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y+0.5f, hitInfo.point.z);
                }
                else
                {
                    // Otherwise, need to determine which place / face we collided with
                    // then use the normal vector to place the new cube accordingly
                    // if (hitInfo.normal == Vector3.up)
                    // {
                    //     goCube.transform.position = new Vector3(hitInfo.transform.position.x,
                    //                                             hitInfo.point.y+0.5f,
                    //                                             hitInfo.transform.position.z);
                    // }
                    // if (hitInfo.normal == Vector3.forward)
                    // {
                    //     goCube.transform.position = new Vector3(hitInfo.transform.position.x,
                    //                                             hitInfo.transform.position.y,
                    //                                             hitInfo.point.z+0.5f);
                    // }
                    // if (hitInfo.normal == Vector3.right)
                    // {
                    //     goCube.transform.position = new Vector3(hitInfo.point.x+0.5f,
                    //                                             hitInfo.transform.position.y,
                    //                                             hitInfo.transform.position.z);
                    // }
                    goCube.transform.position = hitInfo.transform.position + hitInfo.normal;
                }
            }
            else
            {
                // you didn't collide with anything
                Debug.Log($"You selected empty space");
            }
        }
        // 1 would be right click
        // if (Input.GetMouseButton(1))
        // {
        //     Debug.Log("Right mouse button pressed");
        // }
        // if (Input.GetKeyUp(KeyCode.Q))
        // {
        //     direction *= -1;
        // }
        // // There are also get GetKeyUp, GetKeyDown
        // // Make sure to change project to old input library
        // if (Input.GetKey(KeyCode.X))
        // {
        //     // Debug.Log($"You pressed the X Key {transform.name}");
        //     // transform.Translate(new Vector3(1,0,0) * Time.deltaTime)
        //     // transform.Rotate(new Vector3(1,0,0), 1); // axis, degree
        //     // transform.localScale = ; // need to figure this one out
        //     transform.Translate(new Vector3(1 * direction,0,0) * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.Y))
        // {
        //     // transform.Translate(new Vector3(0,1,0) * Time.deltaTime);
        //     transform.Translate(new Vector3(0,1 * direction,0) * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.Z))
        // {
        //     // transform.Translate(new Vector3(0,0,1) * Time.deltaTime);
        //     transform.Translate(new Vector3(0,0,1 * direction) * Time.deltaTime);
        // }
    }

    // When you want the syncronization from one frame to another is exactly the same on every
    // hardware
    // private void FixedUpdate()
    // {
    //     throw new NotImplementedException();
    // }
}
