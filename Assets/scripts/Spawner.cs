using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnInterval = 5.0f; //�G�𐶐�����Ԋu
    public GameObject enemyPrefab;�@//���������G�̃v���n�u
    public AudioClip spawnSound; //�G�������ɍĐ����鉹
    private float spawnTimer;�@//�G�����܂ł̃J�E���g�_�E���^�C�}�[
    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[��������
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        //�^�C�}�[�����炷
        spawnTimer -= Time.deltaTime;

        //�^�C�}�[��0�ȉ��ɂȂ�����G�𐶐�
        if (spawnTimer <= 0)
        {
            SpawnEnemy();

            //�^�C�}�[�����Z�b�g���čăJ�E���g�J�n
            spawnTimer = spawnInterval;
        }
    }

    /// <summary>
    /// �G�𐶐����郁�\�b�h
    /// </summary>
    private void SpawnEnemy()
    {
        //�G�̐���
        GameObject spawnEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        //Rigidbody�R���|�[�l���g������Ύ擾����
        Rigidbody enemyRb = spawnEnemy.GetComponent<Rigidbody>();

        //�X�|�[�������ݒ肳��Ă���΍Đ�
        if (spawnSound != null)
        {
            AudioSource.PlayClipAtPoint(spawnSound, transform.position);
        }
    }
}
