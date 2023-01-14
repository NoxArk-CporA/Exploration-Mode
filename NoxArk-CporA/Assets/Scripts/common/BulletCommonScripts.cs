using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//子弹公共方法
public class BulletCommonScripts : MonoBehaviour
{
    [Tooltip("子弹飞行速度")]
    public float speed;
    [Tooltip("子弹销毁时间")]
    public float lifetime = 30;
    // Start is called before the first frame update
    void Start()
    {
        //定时子弹销毁
        Invoke("SelfDestroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //控制物体往前运动
        this.transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }

    //添加碰撞消息
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("子弹碰撞,other=" + other.name);
        //判断碰撞物体是个以 **开头
        if (other.name.StartsWith("**"))
        {
            //销毁物体
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    //子弹过期销毁
    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
