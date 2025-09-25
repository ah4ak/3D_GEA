using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject enemy;
    public float attackPower = 1;
    public float speed = 20f;           //이동 속도
    public float lifeTime = 2f;        //생존 시간

    void Start()
    {
        //일정 시간 후 자동 삭제
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        //로컬의 forward 방향으로 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().HitEnemy(attackPower);
        }
    }
}
