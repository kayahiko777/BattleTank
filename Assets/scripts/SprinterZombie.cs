using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SprinterZombie : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public float sprintSpeed = 10f;
    public float detectionRange = 15f;
    public int damage = 3;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;

    private NavMeshAgent agent;
    private float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
        {
            target = GameObject.Find("Player");
        }

        agent = GetComponent<NavMeshAgent>();


        agent.speed = sprintSpeed;

        if(target == null)
        {
            Debug.Log("ターゲットが見つかりません");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // プレイヤーとの距離を計算
            float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

            // プレイヤーを検知範囲内で追跡
            if (distanceToPlayer <= detectionRange)
            {
                // ターゲットの位置を目的地に設定
                agent.destination = target.transform.position;
               
                // 攻撃範囲にいる場合攻撃する
                if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
                {
                    AttackPlayer();
                }
            }
        }
    }

    private void AttackPlayer()
    {
        // プレイヤーにダメージを与える
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("スプリンターゾンビがプレイヤーに攻撃しました。ダメージ：" + damage);
        }
        // 次の攻撃までの待機時間を設定
        nextAttackTime = Time.time + attackCooldown;
    }
}
