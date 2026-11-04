using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [Header("移动")]
    public InputAction move;
    [Header("跳跃")]
    public InputAction jump;
    [Header("开火")]
    public InputAction fire;

    private Rigidbody rig;
    private Vector3 dir;
    void Start()
    {
        rig = GetComponent<Rigidbody>();

        move.Enable();

        jump.Enable();
        jump.performed += (context) =>
        {
            rig.AddForce(Vector3.up * 300);
        };

        fire.Enable();
        fire.performed += (context) =>
        {
            //鼠标位置的射线检测
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit))
            {
                //得到子弹飞出去的单位向量
                Vector3 v = hit.point;
                v.y = transform.position.y;
                Vector3 dir = v - transform.position;
                //创建子弹飞出去
                Instantiate(Resources.Load<GameObject>("bullet"),transform.position,Quaternion.LookRotation(dir));
            }
        };
    }

    void Update()
    {
        dir = move.ReadValue<Vector2>();
        dir.z = dir.y;
        dir.y = 0;

        rig.AddForce(dir);
    }
}
