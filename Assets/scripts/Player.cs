using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 5f;  // 通常の移動速度
    public float runSpeed = 10f;  // 加速時の移動速度
    public float accelerationTime = 2f;  // 加速にかかる時間

    private Animator animator;    // Animator コンポーネント
    private Rigidbody rb;         // Rigidbody コンポーネント
    private Vector3 movement;     // 移動方向ベクトル
    private float currentSpeed;   // 現在の速度
    private bool isRunning;       // 加速状態かどうか
    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントの取得
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        currentSpeed = walkSpeed;  // 初期速度は歩行速度
    }

    // Update is called once per frame
    void Update()
    {
        // 入力を取得
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 移動方向を計算
        movement = new Vector3(horizontal, 0f, vertical).normalized;

        // 加速処理
        if (Input.GetKey(KeyCode.LeftShift))  // Shiftキーで加速
        {
            isRunning = true;
            currentSpeed = Mathf.Lerp(currentSpeed, runSpeed, Time.deltaTime / accelerationTime); // 徐々に加速
        }
        else
        {
            isRunning = false;
            currentSpeed = Mathf.Lerp(currentSpeed, walkSpeed, Time.deltaTime / accelerationTime); // 徐々に通常速度に戻す
        }

        // アニメーションの更新
        UpdateAnimation();
    }
    void FixedUpdate()
    {
        // 移動処理
        Move();
    }

    // プレイヤーの移動処理
    void Move()
    {
        if (movement.magnitude > 0)
        {
            // プレイヤーを移動方向に向ける
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(newRotation);

            // プレイヤーを移動させる
            rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
        }
    }

    // アニメーションの更新処理
    void UpdateAnimation()
    {
        // アニメーターのSpeedパラメータに移動の大きさを設定
        float speedPercent = movement.magnitude * (isRunning ? 1.5f : 1f);  // 走っている場合はより大きい値を設定
        animator.SetFloat("Speed", speedPercent);

        // 走行かどうかのブールパラメータ
        animator.SetBool("isRunning", isRunning);
    }
}
