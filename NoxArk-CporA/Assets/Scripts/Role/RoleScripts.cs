using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//角色控制脚本
public class RoleScripts : MonoBehaviour
{
    [Tooltip("子弹节点预制体")]
    public GameObject bulletPrefab;
    [Tooltip("子弹节点的父节点")]
    public Transform bulletFolder;
    //子弹出生点是在用户下创建个空物体进行引用
    [Tooltip("子弹出生点")]
    public Transform firePoint;
    [Tooltip("攻击间隔")]
    public float fireInterval = 0.2f;
    [Tooltip("用户移动")]
    public float moveSpeed = 0.25f;
    [Tooltip("初始化子弹攻速阈值")]
    public float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        //定时生成子弹节点
        InvokeRepeating("Fire", fireInterval, fireInterval);
    }

    // Update is called once per frame
    void Update()
    {
        //控制物体往前运动
        this.transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.Self);
    }

    //开火
    private void Fire()
    {
        //添加子弹目录空物体 用于存放子弹
        //创建子弹节点
        GameObject node = Instantiate(bulletPrefab, bulletFolder);
        //定义复制节点出生点
        node.transform.position = firePoint.position;
        //调用子弹组件初始化攻速
        BulletCommonScripts bulletScripts = node.GetComponent<BulletCommonScripts>();
        bulletScripts.speed = speed;

    }
}
