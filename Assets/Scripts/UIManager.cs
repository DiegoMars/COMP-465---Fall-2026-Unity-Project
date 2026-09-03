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
    public delegate void ChangeGeometry(Button button);
    public static event ChangeGeometry OnChangeGeometry;

    public void OnButtonClicked(Button button)
    {
        Debug.Log($"You selected {button.name}");

        OnChangeGeometry?.Invoke(button);
    }
}
