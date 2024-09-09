using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip getSound;
    public TankHealth th;
    public int reward = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            th = GameObject.Find("Tank").GetComponent<TankHealth>();

            // AddHP()メソッドを呼び出して「引数」にrewardを与えている。
            th.AddHP(reward);

            Destroy(gameObject, 1.0f);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);

            if(getSound != null)
            { 
                AudioSource.PlayClipAtPoint(getSound, transform.position);
            }        
        }
    }
}
