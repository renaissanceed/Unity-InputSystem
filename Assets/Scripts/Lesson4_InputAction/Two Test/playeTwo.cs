using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playeTwo : MonoBehaviour
{
    public InputAction move;
    public InputAction jump;
    public InputAction fire;

    private Rigidbody rig;
    private Vector3 nowV;
    void Start()
    {
        rig = gameObject?.GetComponent<Rigidbody>();
        move.Enable();
        jump.Enable();
        jump.performed += (context) =>
        {
            //跳跃逻辑
            rig.AddForce(Vector3.up * 300);
        };
        fire.Enable();
        fire.performed += (context) =>
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()),out hit))
            {
                Vector3 v = hit.point;
                v.y = transform.position.y;
                Vector3 dir = v - transform.position;
                Instantiate(Resources.Load<GameObject>("bullet"),transform.position,Quaternion.LookRotation(dir));
            }
        };
    }

    void Update()
    {
        nowV = move.ReadValue<Vector2>();
        nowV.z = nowV.y;
        nowV.y = 0;

        rig.AddForce(nowV);
    }
}
