using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotShell : MonoBehaviour
{
    public float shotSpeed;
    public GameObject ShellPrefab;
    public AudioClip shotSound;
    private float interval = 0.75f;
    private float timer = 0;
    public int shotCount;
    public TextMeshProUGUI shellLabel;
    // Start is called before the first frame update
    private void Start()
    {
        shellLabel.text = "" + shotCount;
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーの時間を動かす
        timer += Time.deltaTime;
        // もしもSpaceキーを押したならば（条件）
        // 「Space」の部分を変更することで他のキーにすることができる（ポイント）
        if (Input.GetKeyDown(KeyCode.Space)&& timer > interval&& shotCount > 0)
        {
            shotCount -= 1;
            shellLabel.text ="" + shotCount;
            // タイマーの時間を０に戻す
            timer = 0.0f;
            // 砲弾のプレハブを実体化（インスタンス化）する
            GameObject shell = Instantiate(ShellPrefab,transform.position,Quaternion.identity);
            // 砲弾に付いているRigidbodyコンポーネントにアクセスする。
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            // forward（青軸＝Z軸）の方向に力を加える。
            shellRb.AddForce(transform.forward * shotSpeed);
            // 発射した砲弾を３秒後に破壊する。
            // （重要な考え方）不要になった砲弾はメモリー上から削除すること。
            Destroy(shell, 3.0f);
            // 砲弾の発射音を出す。
           // AudioSource.PlayClipAtPoint(shotSound,transform.position);
        }
    }
}
