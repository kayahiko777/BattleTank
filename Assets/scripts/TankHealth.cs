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
        // ƒV[ƒ‹ƒh‚ÌŽc‚èŽžŠÔ‚ª‚ ‚é‚È‚ç
        if (shield.shieldTime > 0)
        {
            // ‚±‚±‚Åˆ—‚ð‚Æ‚ß‚ÄHP‚ðŒ¸‚ç‚³‚È‚¢
            return;
        }

        // ‚à‚µ‚à‚Ô‚Â‚©‚Á‚Ä‚«‚½‘ŠŽè‚ÌTag‚ªhEnemyShellh‚Å‚ ‚Á‚½‚È‚ç‚ÎiðŒj
        if (other.CompareTag("EnemyShell"))
        {
            // HP‚ð‚P‚¸‚ÂŒ¸­‚³‚¹‚éB
            tankHP -= 1;

            hpLabel.text = "" + tankHP;

            // ‚Ô‚Â‚©‚Á‚Ä‚«‚½‘ŠŽè•ûi“G‚Ì–C’ej‚ð”j‰ó‚·‚éB
            Destroy(other.gameObject);

            if (tankHP > 0)
            {
                GameObject effect1 = Instantiate(effectPrefab1,transform.transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else // ã‚ÌðŒ‚ª¬—§‚µ‚È‚­‚È‚Á‚½ê‡‚É‚Í‚±‚¿‚ç‚ðŽÀs‚·‚éB
            {
                GameObject effect2 = Instantiate(effectPrefab2,transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                // ƒvƒŒ[ƒ„[‚ð”j‰ó‚·‚éB
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
