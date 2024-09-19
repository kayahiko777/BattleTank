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
            Debug.Log("�A�C�e�������");
            // �V�[���h�̔���
            other.GetComponent<Shield>().AddShildTime(shieldDuration);

            // ���̃A�C�e����j�󂷂�
            Destroy(gameObject);
        }
    }
}
