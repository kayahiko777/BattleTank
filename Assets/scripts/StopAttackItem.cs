using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAttackItem : MonoBehaviour
{
    private GameObject[] targets;
    public AudioClip getSound;
    public GameObject effectprefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            targets = GameObject.FindGameObjectsWithTag("EnemyShotShell");

            foreach(GameObject t in targets)
            {
                t.GetComponent<EnemyShotShell>().AddStopTimer(3.0f);
            }
            Destroy(gameObject);           
            GameObject effect = Instantiate(effectprefab, transform.position, Quaternion.identity);
            if(getSound !=null)
            { 
                AudioSource.PlayClipAtPoint(getSound, transform.position);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
