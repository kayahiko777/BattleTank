using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public Transform muzzleTran;
    public GameObject bulletPrefab;

    public AudioClip shotSound;
    public float shotSpeed;

    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �}�E�X�̍��N���b�N��������
        if (Input.GetMouseButtonDown(0))
        {
            {
                Shot();
            }
        }
    void Shot()
        {
            Vector3 spawnPosition = muzzleTran.position + muzzleTran.forward * 0.5f;
            // �e�̔��ˌ��̈ʒu�ɒe�𐶐�
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, muzzleTran.rotation);

            // �e�̐�[�̌������A�e�̔��ˌ��̌����Ă�������ɍ��킹��
            bullet.transform.forward = muzzleTran.forward;
            // �e�̉�]�p�x�𒲐�����
            bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x + offset, bullet.transform.eulerAngles.y, bullet.transform.eulerAngles.z);

            //Debug.Log("�e�̉�]�p�x : " +bullet.transform.eulerAngles);
            // �e�ɃA�^�b�`����Ă��� Rigidbody �̎擾���s���A�擾�ł�����
            if (bullet.TryGetComponent(out Rigidbody rb))
            {
                // �e�𔭎�
                rb.AddForce(muzzleTran.forward * shotSpeed);
                // SE �炷
                //AudioSource.PlayClipAtPoint(shotSound, Camera.main.transform.position);
            }
            else
            {
                Debug.Log("Rigidbody���擾�ł��Ȃ����߁A�e�𔭎˂ł��܂���");
            }
        }
        
    }
}
