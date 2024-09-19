using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public AudioClip getSound;
    public GameObject effectPrefab;
    public float shieldTime;
    GameObject effect;

    public void AddShildTime(float amount)
    {
        shieldTime = amount;

        // エフェクトを作成する
        effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        // エフェクトの親オブジェクトをTankにして一緒に移動するようにする
        effect.transform.SetParent(transform);
        //SEを再生する
        if (getSound != null)
        {
            AudioSource.PlayClipAtPoint(getSound, transform.position);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shieldTime -= Time.deltaTime;
        if (shieldTime < 0)
        {
            shieldTime = 0;
            if (effect != null)
            {
                Destroy(effect);
            }
        }
    }
}
