using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnInterval = 5.0f; //敵を生成する間隔
    public GameObject enemyPrefab;　//生成される敵のプレハブ
    public AudioClip spawnSound; //敵生成時に再生する音
    private float spawnTimer;　//敵生成までのカウントダウンタイマー
    // Start is called before the first frame update
    void Start()
    {
        //タイマーを初期化
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        //タイマーを減らす
        spawnTimer -= Time.deltaTime;

        //タイマーが0以下になったら敵を生成
        if (spawnTimer <= 0)
        {
            SpawnEnemy();

            //タイマーをリセットして再カウント開始
            spawnTimer = spawnInterval;
        }
    }

    /// <summary>
    /// 敵を生成するメソッド
    /// </summary>
    private void SpawnEnemy()
    {
        //敵の生成
        GameObject spawnEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        //Rigidbodyコンポーネントがあれば取得する
        Rigidbody enemyRb = spawnEnemy.GetComponent<Rigidbody>();

        //スポーン音が設定されていれば再生
        if (spawnSound != null)
        {
            AudioSource.PlayClipAtPoint(spawnSound, transform.position);
        }
    }
}
