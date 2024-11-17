using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SprinterZombie : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public float sprintSpeed = 10f;
    public float walkSpeed = 3f;
    public float detectionRange = 15f;
    public int damage = 3;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    public float runDistance = 10f;

    private NavMeshAgent agent;
    private float nextAttackTime = 0f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
        {
            target = GameObject.Find("Player");
        }

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();


        agent.speed = walkSpeed;

        if(target == null)
        {
            Debug.Log("�^�[�Q�b�g��������܂���");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // �v���C���[�Ƃ̋������v�Z
            float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

            // �v���C���[�����m�͈͓��Œǐ�
            if (distanceToPlayer <= detectionRange)
            {
                // �^�[�Q�b�g�̈ʒu��ړI�n�ɐݒ�
                agent.destination = target.transform.position;

                if(distanceToPlayer <= runDistance)
                {
                    agent.speed = sprintSpeed;
                    animator.SetBool("isRunning", true);
                }
                else
                {
                    agent.speed = walkSpeed;
                    animator.SetBool("isRunning", false);
                }
               
                // �U���͈͂ɂ���ꍇ�U������
                if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
                {
                    AttackPlayer();
                }
            }
        }
    }

    private void AttackPlayer()
    {
        // �U���A�j���[�V�������Đ�
        animator.SetTrigger("Attack");

        // �v���C���[�Ƀ_���[�W��^����
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("�X�v�����^�[�]���r���v���C���[�ɍU�����܂����B�_���[�W�F" + damage);
        }
        // ���̍U���܂ł̑ҋ@���Ԃ�ݒ�
        nextAttackTime = Time.time + attackCooldown;
    }
}
