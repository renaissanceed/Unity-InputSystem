using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class DataManager
{
    private static DataManager instance = new DataManager();
    public static DataManager Instance => instance;
    private InputInfo infos;
    public InputInfo InputInfo => infos;
    private string jsonStr;
    private DataManager()
    {
        infos = new InputInfo();
        jsonStr = Resources.Load<TextAsset>("Les").text;
    }
    public InputActionAsset GetActionAsset()
    {
        //使用链式替换，每次替换都是基于上一次的数据替换的

        //上 
        string str = jsonStr.Replace("<up>",infos.up);
        //下
        str = str.Replace("<jump>", infos.jump);
        //左
        str = str.Replace("<left>", infos.left);
        //右
        str = str.Replace("<right>", infos.right);
        //开火
        str = str.Replace("<fire>", infos.fire);
        //跳
        str = str.Replace("<down>", infos.down);

        return InputActionAsset.FromJson(str);
    }
}
