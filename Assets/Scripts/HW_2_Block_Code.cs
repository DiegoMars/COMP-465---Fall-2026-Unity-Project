using UnityEngine;

public class HW_2 : MonoBehaviour
{
    public Material blockMaterial;
    public Material YellowTransMaterial;
    public Material GreenTransMaterial;

    public GameObject followCube;

    void Start()
    {
        followCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        followCube.transform.localScale = new Vector3(1f, 1f, 1f);
        followCube.tag = "FollowCube";
        followCube.layer = LayerMask.NameToLayer("TransparentFX");
        followCube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 100f, LayerMask.GetMask("Default"));
        if (hit)
        {
            if (Input.GetMouseButtonUp(0))
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.localScale = new Vector3(1f, 1f, 1f);
                cube.tag = "MyCube";
                cube.GetComponent<Renderer>().material = blockMaterial;

                if (hitInfo.transform.tag == "Base")
                {
                    cube.transform.position = new Vector3(hitInfo.point.x,
                                                          hitInfo.point.y + 0.5f,
                                                          hitInfo.point.z);
                }
                else
                {
                    cube.transform.position = hitInfo.transform.position + hitInfo.normal;
                }
            }
            else
            {
                followCube.SetActive(true);
                if (hitInfo.transform.tag == "Base")
                {
                    followCube.GetComponent<Renderer>().material = YellowTransMaterial;
                    followCube.transform.position = new Vector3(hitInfo.point.x,
                                                                hitInfo.point.y + 0.5f,
                                                                hitInfo.point.z);
                }
                else if (hitInfo.transform.tag == "MyCube")
                {
                    followCube.GetComponent<Renderer>().material = GreenTransMaterial;
                    followCube.transform.position = hitInfo.transform.position + hitInfo.normal;
                }
            }
        }
        else
        {
            followCube.SetActive(false);
            Debug.Log("No hit");
        }
    }
}
