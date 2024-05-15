using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.XR;
using InputDevice = UnityEngine.XR.InputDevice;

public class ControllerInputs : MonoBehaviour
{
    private void Awake() {}
    private void Start() 
    { 
    
    }

    // Updates are held once per frame
    private void Update() // This is where the inputs will be held
    {
        List<InputDevice> m_device = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right,m_device);
        if (m_device.Count == 1) 
        {
            // One Device Found
            CheckController(m_device[0]);
        }
        else
        {
            
        }

    }

    private void CheckController(InputDevice d) 
    {
        bool primaryButtonDown = false;
        d.TryGetFeatureValue(CommonUsages.primaryButton ,out primaryButtonDown);
        if (primaryButtonDown)
        {

        }
        else 
        {

        }
    }
}
