using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class les2 : MonoBehaviour
{
    Mouse mouse;
    RaycastHit hit;
    Vector3 nowPos;
    int scaleNow = 1;
    bool isNow = false;
    void Start()
    {
        mouse = Mouse.current;
        nowPos = transform.localScale;
    }

    void Update()
    {
        if (mouse.leftButton.wasPressedThisFrame)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(mouse.position.ReadValue()), out hit , 1<<LayerMask.NameToLayer("Cube")))
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                isNow = true;
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                isNow = false;
            }
        }

        if (isNow)
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                scaleNow += 1;
                nowPos = Vector3.one * scaleNow;
            }

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                scaleNow -= 1;
                if (scaleNow < 1)
                {
                    scaleNow = 1;
                }
                nowPos = Vector3.one * scaleNow;
            }

            transform.localScale = Vector3.Lerp(gameObject.transform.localScale, nowPos, Time.deltaTime);
        }
    }
}
