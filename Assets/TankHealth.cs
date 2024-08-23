using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public GameObject effectPrefab1;
    public GameObject effectPrefab2;
    public int tankHP;

    private void OnTriggerEnter(Collider other)
    {
        // �������Ԃ����Ă��������Tag���hEnemyShell�h�ł������Ȃ�΁i�����j
        if (other.CompareTag("EnemyShell"))
        {
            // HP���P������������B
            tankHP -= 1;

            // �Ԃ����Ă���������i�G�̖C�e�j��j�󂷂�B
            Destroy(other.gameObject);

            if (tankHP > 0)
            {
                GameObject effect1 = Instantiate(effectPrefab1,transform.transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else // ��̏������������Ȃ��Ȃ����ꍇ�ɂ͂���������s����B
            {
                GameObject effect2 = Instantiate(effectPrefab2,transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                // �v���[���[��j�󂷂�B
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
