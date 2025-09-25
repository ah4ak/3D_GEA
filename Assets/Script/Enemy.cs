using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 5f;
    public float defaultHealth = 5f;
    public float moveSpeed = 2f;        //�̵� �ӵ�
    private Transform player;

    private void Start()
    {
        defaultHealth = health;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {


        if (player == null) return;

        //�÷��̾������ ���� ���ϱ�
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(player.position);
    }

    public void HitEnemy(float AttackDamage)
    {
        health -= AttackDamage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
