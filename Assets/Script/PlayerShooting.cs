using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;     //프리펩
    public Transform firePoint;         //발사 위치
    Camera cam;

    public GameObject projectilePrefab2;
    public bool Rock;

    private void Start()
    {
        cam = Camera.main;      //메인카메라 가져오기
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
        //화면에서 마우스 광선 쏘기
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPoint;
        targetPoint = ray.GetPoint(50f);
        Vector3 direction = (targetPoint - firePoint.position).normalized;  //방향 벡터

        //projecttile 생성
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
    }

    void ShootRock()
    {
        //화면에서 마우스 광선 쏘기
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPoint;
        targetPoint = ray.GetPoint(50f);
        Vector3 direction = (targetPoint - firePoint.position).normalized;  //방향 벡터

        //projecttile 생성
        GameObject proj = Instantiate(projectilePrefab2, firePoint.position, Quaternion.LookRotation(direction));
    }
}
