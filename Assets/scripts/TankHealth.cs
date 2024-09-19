using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TankHealth : MonoBehaviour
{
    public GameObject effectPrefab1;
    public GameObject effectPrefab2;
    public int tankHP;
    public TextMeshProUGUI hpLabel;
    public Shield shield;

    private int tankMaxHP = 10;

    private void OnTriggerEnter(Collider other)
    {
        // �V�[���h�̎c�莞�Ԃ�����Ȃ�
        if (shield.shieldTime > 0)
        {
            // �����ŏ������Ƃ߂�HP�����炳�Ȃ�
            return;
        }

        // �������Ԃ����Ă��������Tag���hEnemyShell�h�ł������Ȃ�΁i�����j
        if (other.CompareTag("EnemyShell"))
        {
            // HP���P������������B
            tankHP -= 1;

            hpLabel.text = "" + tankHP;

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
               // Destroy(gameObject);

                this.gameObject.SetActive(false);

                Invoke("GoToGameOver", 1.0f);
            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void AddHP(int amount)
    {
        tankHP += amount;

        if(tankHP > tankMaxHP)
        {
            tankHP = tankMaxHP;
        }

        hpLabel.text = "" + tankHP;
    }

    // Start is called before the first frame update
    void Start()
    {
        tankHP = tankMaxHP;
        hpLabel.text = "" + tankHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
