using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player2 : MonoBehaviour
{
    private Les6 actions;
    private Vector3 dir;
    public float moveSpeed = 20;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        actions = new Les6();

        actions.player.move.Enable();

        actions.player.jump.Enable();
        actions.player.jump.performed += (context) =>
        {
            if (transform.position.y <= 3f)
            {
                //跳跃逻辑
                rb.AddForce(Vector3.up * 300);
            }  
        };

        actions.player.fire.Enable();
        actions.player.fire.performed += (context) =>
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()),out hit))
            {
                Vector3 v = hit.point;
                v.y = transform.position.y;
                Instantiate(Resources.Load<GameObject>("bullet"),transform.position,Quaternion.LookRotation(v));
            }
        };
    }

    void Update()
    {
        dir = actions.player.move.ReadValue<Vector2>();
        dir.z = dir.y;
        dir.y = 0;

        transform.Translate(dir * Time.deltaTime * moveSpeed);
    }
}
