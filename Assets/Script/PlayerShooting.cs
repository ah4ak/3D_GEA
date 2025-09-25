using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;     //������
    public Transform firePoint;         //�߻� ��ġ
    Camera cam;

    public GameObject projectilePrefab2;
    public bool Rock;

    private void Start()
    {
        cam = Camera.main;      //����ī�޶� ��������
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Rock = !Rock;
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(Rock == false)
            {
                Shoot();
            }
            else
            {
                ShootRock();
            }
        }
    }

    void Shoot()
    {
        //ȭ�鿡�� ���콺 ���� ���
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPoint;
        targetPoint = ray.GetPoint(50f);
        Vector3 direction = (targetPoint - firePoint.position).normalized;  //���� ����

        //projecttile ����
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
    }

    void ShootRock()
    {
        //ȭ�鿡�� ���콺 ���� ���
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPoint;
        targetPoint = ray.GetPoint(50f);
        Vector3 direction = (targetPoint - firePoint.position).normalized;  //���� ����

        //projecttile ����
        GameObject proj = Instantiate(projectilePrefab2, firePoint.position, Quaternion.LookRotation(direction));
    }
}
