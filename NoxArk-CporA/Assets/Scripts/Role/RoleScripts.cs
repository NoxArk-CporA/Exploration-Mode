using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ɫ���ƽű�
public class RoleScripts : MonoBehaviour
{
    [Tooltip("�ӵ��ڵ�Ԥ����")]
    public GameObject bulletPrefab;
    [Tooltip("�ӵ��ڵ�ĸ��ڵ�")]
    public Transform bulletFolder;
    //�ӵ������������û��´������������������
    [Tooltip("�ӵ�������")]
    public Transform firePoint;
    [Tooltip("�������")]
    public float fireInterval = 0.2f;
    [Tooltip("�û��ƶ�")]
    public float moveSpeed = 0.25f;
    [Tooltip("��ʼ���ӵ�������ֵ")]
    public float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        //��ʱ�����ӵ��ڵ�
        InvokeRepeating("Fire", fireInterval, fireInterval);
    }

    // Update is called once per frame
    void Update()
    {
        //����������ǰ�˶�
        this.transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.Self);
    }

    //����
    private void Fire()
    {
        //����ӵ�Ŀ¼������ ���ڴ���ӵ�
        //�����ӵ��ڵ�
        GameObject node = Instantiate(bulletPrefab, bulletFolder);
        //���帴�ƽڵ������
        node.transform.position = firePoint.position;
        //�����ӵ������ʼ������
        BulletCommonScripts bulletScripts = node.GetComponent<BulletCommonScripts>();
        bulletScripts.speed = speed;

    }
}
