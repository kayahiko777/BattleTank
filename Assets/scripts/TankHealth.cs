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
        // シールドの残り時間があるなら
        if (shield.shieldTime > 0)
        {
            // ここで処理をとめてHPを減らさない
            return;
        }

        // もしもぶつかってきた相手のTagが”EnemyShell”であったならば（条件）
        if (other.CompareTag("EnemyShell"))
        {
            // HPを１ずつ減少させる。
            tankHP -= 1;

            hpLabel.text = "" + tankHP;

            // ぶつかってきた相手方（敵の砲弾）を破壊する。
            Destroy(other.gameObject);

            if (tankHP > 0)
            {
                GameObject effect1 = Instantiate(effectPrefab1,transform.transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else // 上の条件が成立しなくなった場合にはこちらを実行する。
            {
                GameObject effect2 = Instantiate(effectPrefab2,transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                // プレーヤーを破壊する。
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
