using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单人游戏-相机脚本
/// </summary>


public class Local_camera : MonoBehaviour
{
    GameObject player;
    //玩家
    public Vector3 aimpos,disvec;
    //相机移动目标点，玩家指向相机的向量
    float tan, height, trigle;
    //夹角高度
    public static GameObject cme;
    //相机(单列)
    public static Local_camera cm;
    //单例


    private void Awake()
    {
        cme = this.gameObject;
        cm = GetComponent<Local_camera>();
    }

    void Start()
    {

        Init();
    }
    void LateUpdate()
    {
        Set_Aimpos();

        Move_to_aimpos();
    }

    ///////////////////    工具函数   ////////////////////////
    void Init()
    {
        height = 10;
        trigle = 40f;
        tan = Mathf.Tan(trigle);
        player = move.player;

        Set_disvec();
        //设置默认disvec
        Set_Aimpos();
        //设置目标点
        Init_camera();
        //初始化相机
    }
    //初始化

    void Set_disvec()
    {
        Vector3 touying=(transform.position-player.transform.position).normalized;
        touying = touying * (height / tan);
        disvec.Set(touying.x, height, touying.z);
    }
    void Set_Aimpos()
    {
        aimpos = player.transform.position + disvec;
    }
    void Init_camera()
    {
        transform.position = aimpos;
        transform.LookAt(player.transform);
        transform.GetComponent<Camera>().orthographic = true;
    }
    private void Move_to_aimpos()
    {
        transform.position = Vector3.Lerp(transform.position, aimpos, 0.01f);
    }


    ///////////////////    外部接口   ////////////////////////
    
    public Vector3 Get_Right()
    {
        Vector3 right = transform.right;
        right.Set(right.x, 0f, right.z);
        return right.normalized;
    }
    public Vector3 Get_Forward()
    {
        Vector3 forward = transform.forward;
        forward.Set(forward.x, 0f, forward.z);
        return forward.normalized;
    }
}
