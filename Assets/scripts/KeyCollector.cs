using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public DoorController doorController; // 扉の制御スクリプトへの参照

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Key")) // 鍵オブジェクトに "Key" タグを設定しておく
        {
            doorController.AddKey(); // 鍵の数を追加
            Destroy(other.gameObject); // 鍵オブジェクトを削除
        }
    }
}
