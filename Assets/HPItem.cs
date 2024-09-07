using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip getSound;
    private TankHealth th;
    private int reward = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            th = GameObject.Find("Tank").GetComponent<TankHealth>();

            // AddHP()���\�b�h���Ăяo���āu�����v��reward��^���Ă���B
            th.AddHP(reward);

            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
        }
    }
}
