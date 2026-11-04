using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class les3 : MonoBehaviour
{
    Gamepad pad;
    void Start()
    {
        pad = Gamepad.current;
        if (pad!=null)
        {
            return;
        }
    }

    void Update()
    {
        print(pad.leftStick.ReadValue());
        print(pad.rightStick.ReadValue());
        if (pad.leftStickButton.wasPressedThisFrame)
        {
            print("左摇杆按下");
        }
        if (pad.rightStickButton.wasReleasedThisFrame)
        {
            print("右摇杆抬起");
        }
        if (pad.leftStickButton.isPressed)
        {
            print("左摇杆长按");
        }

        if (pad.dpad.left.wasPressedThisFrame)
        {
            print("左");
        }
        if (pad.dpad.right.wasPressedThisFrame)
        {
            print("右");
        }
        if (pad.dpad.up.wasPressedThisFrame)
        {
            print("上");
        }
        if (pad.dpad.down.wasPressedThisFrame)
        {
            print("下");
        }
    }
}
