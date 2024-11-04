using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WeaponData
{
    public string weaponName;  // ����̖���
    public int weaponNo;        // ����̒ʂ��ԍ�
    public int maxBullet;       // �e�̍ő呕�U�e��
    public float reloadTime;    // �e�̍đ��U�ɂ����鎞��
    public int bulletPower;     // �e�̍U����
    public float shootInterval; // �A���Œe�𔭎˂���ۂ̊Ԋu
    public float shootRange;    // �e�̎˒�����
    public Sprite weaponIcon;   // ����̃A�C�R���摜
}
