using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    public float shieldDuration;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("アイテム取った");
            // シールドの発動
            other.GetComponent<Shield>().AddShildTime(shieldDuration);

            // このアイテムを破壊する
            Destroy(gameObject);
        }
    }
}
