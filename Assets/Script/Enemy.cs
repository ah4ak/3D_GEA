using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 5f;
    public float defaultHealth = 5f;
    public float moveSpeed = 2f;        //이동 속도
    private Transform player;

    private void Start()
    {
        defaultHealth = health;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {


        if (player == null) return;

        //플레이어까지의 방향 구하기
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
