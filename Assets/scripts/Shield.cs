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

        // �G�t�F�N�g���쐬����
        effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        // �G�t�F�N�g�̐e�I�u�W�F�N�g��Tank�ɂ��Ĉꏏ�Ɉړ�����悤�ɂ���
        effect.transform.SetParent(transform);
        //SE���Đ�����
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
