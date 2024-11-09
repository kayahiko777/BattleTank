using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("�v���C���[���_���[�W���󂯂܂����B�c��HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("�v���C���[�����S���܂����B");
        // �Q�[���I�[�o�[�����������ɒǉ�
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
