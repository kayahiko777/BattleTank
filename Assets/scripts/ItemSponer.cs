using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSponer : MonoBehaviour
{
    public float spawnInterval = 5.0f; //アイテムを生成する間隔
    private float spawnTimer;　//アイテム生成までのカウントダウンタイマー
    public GameObject[] itemPrefabs;
    public bool isSpawn; //trueなら生成済みでプレイヤーが取ってないfalseなら生成していないのでタイマーを動かす
    // Start is called before the first frame update
    void Start()
    {
        //タイマーを初期化
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isSpawn) 
        // {
        // return;
        // }

        //アイテムを作ってなかったら
        if (isSpawn == false)
        {
            //タイマーを減らす
            spawnTimer -= Time.deltaTime; 

            //タイマーが0以下になったら敵を生成
            if (spawnTimer <= 0)
            {
                //Debug.Log(spawnTimer);
                SpawnItem();
                spawnTimer = spawnInterval;
            }
        }
    }

    private void SpawnItem()
    {
        isSpawn = true;
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        GameObject spawnItem = Instantiate(itemPrefabs[randomIndex],transform.position,Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーがスポナーに侵入したら
        if (other.CompareTag("Player"))
        {
            //アイテムをとったことにして再度タイマーが動くようにする
            isSpawn = false;
        }
    }
}
