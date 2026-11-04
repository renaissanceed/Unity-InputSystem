using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public enum BTN_TYPE
{
    UP, DOWN, LEFT, RIGHT, FIRE, JUMP
}
public class ChangeInputPanel : MonoBehaviour
{
    public TextMeshProUGUI txtUp;
    public TextMeshProUGUI txtDwon;
    public TextMeshProUGUI txtLeft;
    public TextMeshProUGUI txtRight;
    public TextMeshProUGUI txtFire;
    public TextMeshProUGUI txtJump;

    public Button btnUp;
    public Button btnDwon;
    public Button btnLeft;
    public Button btnRight;
    public Button btnFire;
    public Button btnJump;

    private InputInfo infos;
    //记录键位
    private BTN_TYPE nowType;
    //玩家
    public PlayerLes player;
    //键位字典
    private Dictionary<string, string> dicKey;
    void Start()
    {
        infos = DataManager.Instance.InputInfo;
        UpdateBtnInfo();

        btnUp.onClick.AddListener(() =>
        {
            ChangeButton(BTN_TYPE.UP);
        });

        btnDwon.onClick.AddListener(() =>
        {
            ChangeButton(BTN_TYPE.DOWN);
        });

        btnLeft.onClick.AddListener(() =>
        {
            ChangeButton(BTN_TYPE.LEFT);
        });

        btnRight.onClick.AddListener(() =>
        {
            ChangeButton(BTN_TYPE.RIGHT);
        });

        btnFire.onClick.AddListener(() =>
        {
            ChangeButton(BTN_TYPE.FIRE);
        });

        btnJump.onClick.AddListener(() =>
        {
            ChangeButton(BTN_TYPE.JUMP);
        });

    }

    private void ChangeButton(BTN_TYPE type)
    {
        nowType = type;
        InputSystem.onAnyButtonPress.CallOnce(ChangeButtonReally);
    }

    private void ChangeButtonReally(InputControl control)
    {
        string[] str = control.path.Split('/');
        string path = "<" + str[1] + ">/" + str[2];

        //改键逻辑
        switch (nowType)
        {
            case BTN_TYPE.UP:
                infos.up = path;
                break;
            case BTN_TYPE.DOWN:
                infos.down = path;
                break;
            case BTN_TYPE.LEFT:
                infos.left = path;
                break;
            case BTN_TYPE.RIGHT:
                infos.right = path;
                break;
            case BTN_TYPE.FIRE:
                infos.fire = path;
                break;
            case BTN_TYPE.JUMP:
                infos.jump = path;
                break;
        }

        //更新信息到界面上
        UpdateBtnInfo();

        //让玩家产生改键效果
        player.ChangeInput();
    }

    //初始化文本信息
    private void UpdateBtnInfo()
    {
        txtUp.text = infos.up;
        txtDwon.text = infos.down;
        txtLeft.text = infos.left;
        txtRight.text = infos.right;

        txtFire.text = infos.fire;
        txtJump.text = infos.jump;
    }
}
