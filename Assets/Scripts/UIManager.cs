using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // public void OnButtonClicked(int value)
    // {
    //     switch (value)
    //     {
    //         case 0:
    //             Debug.Log($"You selected {value}: Cube");
    //             break;
    //         case 1:
    //             Debug.Log($"You selected {value}: Sphere");
    //             break;
    //         case 2:
    //             Debug.Log($"You selected {value}: Capsule");
    //             break;
    //     }
    // }

    // Delegate here basically means something else will delegate it
    public delegate void ChangeGeometry(int index);
    public static event ChangeGeometry OnChangeGeometry;

    public delegate void ChangeColor(int index);
    public static event ChangeColor OnChangeColor;

    public void OnShapeSelection(int index)
    {
        Debug.Log($"You selected {index}");

        OnChangeGeometry?.Invoke(index);
    }

    public void OnColorselection(int index)
    {
        OnChangeColor?.Invoke(index);
    }
}
