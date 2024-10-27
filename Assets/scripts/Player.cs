using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 5f;  // �ʏ�̈ړ����x
    public float runSpeed = 10f;  // �������̈ړ����x
    public float accelerationTime = 2f;  // �����ɂ����鎞��

    private Animator animator;    // Animator �R���|�[�l���g
    private Rigidbody rb;         // Rigidbody �R���|�[�l���g
    private Vector3 movement;     // �ړ������x�N�g��
    private float currentSpeed;   // ���݂̑��x
    private bool isRunning;       // ������Ԃ��ǂ���
    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g�̎擾
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        currentSpeed = walkSpeed;  // �������x�͕��s���x
    }

    // Update is called once per frame
    void Update()
    {
        // ���͂��擾
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �ړ��������v�Z
        movement = new Vector3(horizontal, 0f, vertical).normalized;

        // ��������
        if (Input.GetKey(KeyCode.LeftShift))  // Shift�L�[�ŉ���
        {
            isRunning = true;
            currentSpeed = Mathf.Lerp(currentSpeed, runSpeed, Time.deltaTime / accelerationTime); // ���X�ɉ���
        }
        else
        {
            isRunning = false;
            currentSpeed = Mathf.Lerp(currentSpeed, walkSpeed, Time.deltaTime / accelerationTime); // ���X�ɒʏ푬�x�ɖ߂�
        }

        // �A�j���[�V�����̍X�V
        UpdateAnimation();
    }
    void FixedUpdate()
    {
        // �ړ�����
        Move();
    }

    // �v���C���[�̈ړ�����
    void Move()
    {
        if (movement.magnitude > 0)
        {
            // �v���C���[���ړ������Ɍ�����
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(newRotation);

            // �v���C���[���ړ�������
            rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
        }
    }

    // �A�j���[�V�����̍X�V����
    void UpdateAnimation()
    {
        // �A�j���[�^�[��Speed�p�����[�^�Ɉړ��̑傫����ݒ�
        float speedPercent = movement.magnitude * (isRunning ? 1.5f : 1f);  // �����Ă���ꍇ�͂��傫���l��ݒ�
        animator.SetFloat("Speed", speedPercent);

        // ���s���ǂ����̃u�[���p�����[�^
        animator.SetBool("isRunning", isRunning);
    }
}
