using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject enemy;
    public float attackPower = 1;
    public float speed = 20f;           //�̵� �ӵ�
    public float lifeTime = 2f;        //���� �ð�

    void Start()
    {
        //���� �ð� �� �ڵ� ����
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        //������ forward �������� �̵�
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
