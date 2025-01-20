using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class can be used with input system to toggle the menu.
/// </summary>
public class MenuSwitch : MonoBehaviour
{
    public bool disableMenuOnStart = true;

    // Start is called before the first frame update
    void Start()
    {
        if (disableMenuOnStart)
            gameObject.SetActive(false);
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);       
    }
}
