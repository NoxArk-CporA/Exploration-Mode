using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ӵ���������
public class BulletCommonScripts : MonoBehaviour
{
    [Tooltip("�ӵ������ٶ�")]
    public float speed;
    [Tooltip("�ӵ�����ʱ��")]
    public float lifetime = 30;
    // Start is called before the first frame update
    void Start()
    {
        //��ʱ�ӵ�����
        Invoke("SelfDestroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //����������ǰ�˶�
        this.transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }

    //�����ײ��Ϣ
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�ӵ���ײ,other=" + other.name);
        //�ж���ײ�����Ǹ��� **��ͷ
        if (other.name.StartsWith("**"))
        {
            //��������
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    //�ӵ���������
    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
