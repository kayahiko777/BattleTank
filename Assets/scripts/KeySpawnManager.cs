using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeySpawnManager : MonoBehaviour
{
    public GameObject keyPrefab; // ���̃v���n�u
    public List<Transform> keySpawnPoints; // ���̏o���n�_�̃��X�g
    // Start is called before the first frame update
    void Start()
    {
        SpawnKeys(); // �Q�[���J�n���Ɍ��𐶐�
    }


    private void SpawnKeys()
    {
        // ���̏o���n�_�������_���ɑI��
        HashSet<int> selectedIndexs = new HashSet<int>();
        while(selectedIndexs.Count < 3)
        {
            selectedIndexs.Add(Random.Range(0,keySpawnPoints.Count));
        }
        foreach (int index in selectedIndexs)
        {
            // ���𐶐�
            Instantiate(keyPrefab,keySpawnPoints[index].position,Quaternion.identity);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
