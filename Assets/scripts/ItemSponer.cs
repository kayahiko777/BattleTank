using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSponer : MonoBehaviour
{
    public float spawnInterval = 5.0f; //�A�C�e���𐶐�����Ԋu
    private float spawnTimer;�@//�A�C�e�������܂ł̃J�E���g�_�E���^�C�}�[
    public GameObject[] itemPrefabs;
    public bool isSpawn; //true�Ȃ琶���ς݂Ńv���C���[������ĂȂ�false�Ȃ琶�����Ă��Ȃ��̂Ń^�C�}�[�𓮂���
    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[��������
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isSpawn) 
        // {
        // return;
        // }

        //�A�C�e��������ĂȂ�������
        if (isSpawn == false)
        {
            //�^�C�}�[�����炷
            spawnTimer -= Time.deltaTime; 

            //�^�C�}�[��0�ȉ��ɂȂ�����G�𐶐�
            if (spawnTimer <= 0)
            {
                //Debug.Log(spawnTimer);
                SpawnItem();
                spawnTimer = spawnInterval;
            }
        }
    }

    private void SpawnItem()
    {
        isSpawn = true;
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        GameObject spawnItem = Instantiate(itemPrefabs[randomIndex],transform.position,Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[���X�|�i�[�ɐN��������
        if (other.CompareTag("Player"))
        {
            //�A�C�e�����Ƃ������Ƃɂ��čēx�^�C�}�[�������悤�ɂ���
            isSpawn = false;
        }
    }
}
