using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 歩く時の移動速度
    public float walkSpeed;
    // Shiftキーを押している際の移動速度(倍率ではありません)
    public float runSpeed;
    // 現在の移動速度
    public float speed;
    // 移動値
    private Vector3 movement;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbodyコンポーネントを取得し、なければ追加する
        if(!TryGetComponent(out rb))
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        // 回転を固定する
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        // 初期の移動速度を設定
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        // それぞれのキー入力値を代入
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        // Shiftキーを押している場合は速度を増加させる
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
        // キー入力された値を移動方向値として代入
        movement = new Vector3(moveH, 0, moveV);

        // 移動方向に速度を掛ける
        movement *= speed;
    }

    void FixedUpdate()
    {
        
        
        Move();
    }
    /// <summary>
    /// プレイヤーを移動させる
    /// </summary>
    /// <param name="moveDir">移動方向</param>
    void Move()
    {
        // カメラの forward と right ベクトルを水平面上に投影して、移動方向を計算(単位ベクトルになっているので正規化不要)
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        // プレイヤーが斜めに傾いている際に前後移動すると空中に浮かんでしまう
        // その挙動を防ぐため、それぞれの Y 軸の成分を 0 にして除去する
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        // カメラの正面方向と右方向のベクトルを使用して、プレイヤーの移動方向を計算
        Vector3 desiredMove = cameraForward * movement.z + cameraRight * movement.x;
        // Rigidbody を使って移動。また、ジャンプと落下を考慮して重力(rb.velocity.y)を反映
        rb.velocity = desiredMove + new Vector3(0,rb.velocity.y,0);
    }
}
