using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeySpawnManager : MonoBehaviour
{
    public GameObject keyPrefab; // 鍵のプレハブ
    public List<Transform> keySpawnPoints; // 鍵の出現地点のリスト
    // Start is called before the first frame update
    void Start()
    {
        SpawnKeys(); // ゲーム開始時に鍵を生成
    }


    private void SpawnKeys()
    {
        // 鍵の出現地点をランダムに選ぶ
        HashSet<int> selectedIndexs = new HashSet<int>();
        while(selectedIndexs.Count < 3)
        {
            int index = Random.Range(0, keySpawnPoints.Count);
            selectedIndexs.Add(index);
        }
        foreach (int index in selectedIndexs)
        {
            // 鍵を生成
            Instantiate(keyPrefab, keySpawnPoints[index].position, Quaternion.identity);
        }
        foreach (Transform tran in keySpawnPoints)
        {

        }
    }

    
    public void SpawnKeyfromEnemy(Transform enemyTran)
    {
        Instantiate(keyPrefab, enemyTran.position, Quaternion.identity);
    }
}
