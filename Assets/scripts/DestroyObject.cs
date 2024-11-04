using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject effectPrefab;

    public GameObject effectPrefab2; // 2��ޖڂ̃G�t�F�N�g�����邽�߂̔�
    public int objectHP;
    //�z��
    public GameObject[] itemPrefabs;
    public float itemHigh;
    public int scoreValue;
    public bool isBoss;
    private ScoreManager sm;
    private GameManager gameManager;
    // ���̃��\�b�h�̓R���C�_�[���m���Ԃ������u�ԂɌĂяo�����
    private void OnTriggerEnter(Collider other)
    {
        // �������Ԃ����������Tag��Shell�Ƃ������O�������Ă������Ȃ�΁i�����j
        if (other.CompareTag("Shell"))
        {
            objectHP -= 1;
           

            if (objectHP > 0)
            {
                // �Ԃ����Ă����I�u�W�F�N�g��j�󂷂�
                // other���ǂ��ƌq�����Ă��邩�l���Ă݂悤�I
                Destroy(other.gameObject);

                // �G�t�F�N�g�����̉�����
               // GameObject effect = Instantiate(effectPrefab,other.transform.position, Quaternion.identity);

                // �G�t�F�N�g���Q�b��ɏ���
               // Destroy(effect, 2.0f);
            }
            else
            {
                Destroy(other.gameObject);

                //GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
               // Destroy(effect2, 2.0f);
                // ���̃X�N���v�g�����Ă���I�u�W�F�N�g��j�󂷂�ithis�͏ȗ����\�j
                Destroy(this.gameObject);

                sm.AddScore(scoreValue);

                int itemNumber = Random.Range(0,100);

                if(itemPrefabs.Length != 0)
                { // �i�|�C���g�jpos.y + 0.6f�̃R�[�h�ŃA�C�e���̏o���ꏊ�́u�����v�𒲐����Ă��܂��B
                    Vector3 pos = transform.position;
                    if(itemNumber < 10)
                    {
                        Instantiate(itemPrefabs[0], new Vector3(pos.x, pos.y + itemHigh, pos.z), Quaternion.identity);
                    }

                    else if(itemNumber < 40)
                    {
                        Instantiate(itemPrefabs[1], new Vector3(pos.x, pos.y + itemHigh, pos.z), Quaternion.identity);
                    }
                    else
                    {// itenMunber�̐����ɂ���āA�o��A�C�e�����ω�����
                        Instantiate(itemPrefabs[2], new Vector3(pos.x, pos.y + itemHigh, pos.z), Quaternion.identity);
                    }
                    
                } 
                
                // �{�X�̏ꍇ
                if(isBoss == true)
                {
                    // �{�X�̓|�����������Z����
                    gameManager.AddBossCount();
                }
            }
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
