using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public SmartPhoneManager smartPhoneManager;
    // Start is called before the first frame update
    void Start()
    {
        smartPhoneManager = GetComponent<SmartPhoneManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ToggleSmartPhoneWindow();
        }
    }

    public void ToggleSmartPhoneWindow()
    {
        if (smartPhoneManager.isAnimating == false)
        {
            if (smartPhoneManager.isVisible == false)
                smartPhoneManager.OpenSmartPhoneWindow();
            else
                smartPhoneManager.CloseSmartPhoneWindow();
        }
    }
}
