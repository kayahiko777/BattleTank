using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public DoorController doorController; // ���̐���X�N���v�g�ւ̎Q��

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Key")) // ���I�u�W�F�N�g�� "Key" �^�O��ݒ肵�Ă���
        {
            doorController.AddKey(); // ���̐���ǉ�
            Destroy(other.gameObject); // ���I�u�W�F�N�g���폜
        }
    }
}
