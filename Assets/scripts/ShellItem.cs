using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helltem : MonoBehaviour
{

    public AudioClip getSound;
    public GameObject effectPrefab;
    private ShotShell ss;
    private int reward = 5;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ss= GameObject.Find("ShotShell").GetComponent<ShotShell>();

            ss.AddShell(reward);

            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab,transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);
            if(getSound != null)
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
