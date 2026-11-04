using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class les11 : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rig;
    private Vector3 dir;
    private Vector3 pos;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += (context) =>
        {
            switch (context.action.name)
            {
                case "Fire":
                    if (context.performed)
                    {
                        RaycastHit hit;
                        if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()),out hit))
                        {
                            pos = hit.point;
                            pos -= transform.position;
                            Instantiate(Resources.Load<GameObject>("bullet"),transform.position,Quaternion.LookRotation(pos));
                        }
                    }
                    break;
                case "Move":
                    dir = context.action.ReadValue<Vector2>();
                    dir.z = dir.y;
                    dir.y = 0;
                    break;
                case "Jump":
                    rig.AddForce(Vector3.up * 100);
                    break;
            }
        };
    }

    void Update()
    {
        transform.Translate(dir * Time.deltaTime * 10);
    }
}
