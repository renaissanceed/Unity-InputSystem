using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerinputmgr : MonoBehaviour
{
    void Start()
    {
        PlayerInputManager.instance.onPlayerJoined += (playerInput) =>
        {
            print("玩家加入");
        };

        PlayerInputManager.instance.onPlayerLeft += (playerInput) =>
        {
            print("玩家离开");
        };

    }

    void Update()
    {
        
    }
}
