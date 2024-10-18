using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �������̈ړ����x
    public float walkSpeed;
    // Shift�L�[�������Ă���ۂ̈ړ����x(�{���ł͂���܂���)
    public float runSpeed;
    // ���݂̈ړ����x
    public float speed;
    // �ړ��l
    private Vector3 movement;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody�R���|�[�l���g���擾���A�Ȃ���Βǉ�����
        if(!TryGetComponent(out rb))
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        // ��]���Œ肷��
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        // �����̈ړ����x��ݒ�
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        // ���ꂼ��̃L�[���͒l����
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        // Shift�L�[�������Ă���ꍇ�͑��x�𑝉�������
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
        // �L�[���͂��ꂽ�l���ړ������l�Ƃ��đ��
        movement = new Vector3(moveH, 0, moveV);

        // �ړ������ɑ��x���|����
        movement *= speed;
    }

    void FixedUpdate()
    {
        
        
        Move();
    }
    /// <summary>
    /// �v���C���[���ړ�������
    /// </summary>
    /// <param name="moveDir">�ړ�����</param>
    void Move()
    {
        // �J������ forward �� right �x�N�g���𐅕��ʏ�ɓ��e���āA�ړ��������v�Z(�P�ʃx�N�g���ɂȂ��Ă���̂Ő��K���s�v)
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        // �v���C���[���΂߂ɌX���Ă���ۂɑO��ړ�����Ƌ󒆂ɕ�����ł��܂�
        // ���̋�����h�����߁A���ꂼ��� Y ���̐����� 0 �ɂ��ď�������
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        // �J�����̐��ʕ����ƉE�����̃x�N�g�����g�p���āA�v���C���[�̈ړ��������v�Z
        Vector3 desiredMove = cameraForward * movement.z + cameraRight * movement.x;
        // Rigidbody ���g���Ĉړ��B�܂��A�W�����v�Ɨ������l�����ďd��(rb.velocity.y)�𔽉f
        rb.velocity = desiredMove + new Vector3(0,rb.velocity.y,0);
    }
}
