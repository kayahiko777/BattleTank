using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;
    public GameObject enemyShellPrefab;
    public AudioClip shotSound;
    private int count;

    private float stopTimer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �u%�v�Ɓu==�v�̈Ӗ����l���悤�i�|�C���g�j
        count += 1;

        stopTimer -= Time.deltaTime;

        if(stopTimer < 0)
        {
            stopTimer = 0;

        }
        if(count % 100 == 0&& stopTimer <= 0)
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab,transform.position, Quaternion.identity);
            Rigidbody enemyShellRb =enemyShell.GetComponent<Rigidbody>();

            // forward��Z�������i�������j�E�E�E�����̕����ɗ͂�������
            enemyShellRb.AddForce(transform.forward * shotSpeed);
            if (shotSound != null)
            {
                AudioSource.PlayClipAtPoint(shotSound, transform.position);
            }
            Destroy(enemyShell, 3.0f);
        }
    }

    public void AddStopTimer(float amount)
    {
        stopTimer += amount;
    }
}