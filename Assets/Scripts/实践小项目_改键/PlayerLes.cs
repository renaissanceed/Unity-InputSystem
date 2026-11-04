using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLes : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector3 dir, pos;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        ChangeInput();
        //需要手动启用
        playerInput.actions.Enable();
        
        playerInput.onActionTriggered += (context) =>
        {
            
            switch (context.action.name)
            {
                case "Move":
                    dir = context.action.ReadValue<Vector2>();
                    dir.z = dir.y;
                    dir.y = 0;
                    break;
                case "Fire":
                    if (context.performed)
                    {
                        RaycastHit hit;
                        if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit))
                        {
                            pos = hit.point;
                            pos -= transform.position;
                            Instantiate(Resources.Load<GameObject>("bullet"), transform.position, Quaternion.LookRotation(pos));
                        }
                    }
                    break;
                case "Jump":
                    if (context.performed)
                        rb.AddForce(Vector3.up * 200);
                    break;
            }
        };
    }

    void Update()
    {
        transform.Translate(dir * Time.deltaTime * 10);
    }

    //改键
    public void ChangeInput()
    {
        playerInput.actions = DataManager.Instance.GetActionAsset();
    }
}
