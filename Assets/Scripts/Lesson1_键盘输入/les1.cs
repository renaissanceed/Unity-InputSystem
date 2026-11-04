using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class les1 : MonoBehaviour
{
    Vector3 nowPos;
    int scaleNow = 1;
    private void Start()
    {
        nowPos = transform.localScale;
    }
    void Update()
    {

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            scaleNow += 1;
            nowPos = Vector3.one* scaleNow;
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
