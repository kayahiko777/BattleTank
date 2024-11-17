using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject effectPrefab;

    public GameObject effectPrefab2; // 2種類目のエフェクトを入れるための箱
    public int objectHP;
    //配列
    public GameObject[] itemPrefabs;
    public float itemHigh;
    public int scoreValue;
    public bool isBoss;
    public int keyRate;
    private ScoreManager sm;
    private GameManager gameManager;
    private Animator animator;
    private bool isDead;
    // このメソッドはコライダー同士がぶつかった瞬間に呼び出される
    private void OnTriggerEnter(Collider other)
    {
        if(isDead == true)
        { 
            return; 
        }
        // もしもぶつかった相手のTagにShellという名前が書いてあったならば（条件）
        if (other.CompareTag("Shell"))
        {
            objectHP -= 1;
           

            if (objectHP > 0)
            {
                // ぶつかってきたオブジェクトを破壊する
                // otherがどこと繋がっているか考えてみよう！
                Destroy(other.gameObject);

                // エフェクトを実体化する
               // GameObject effect = Instantiate(effectPrefab,other.transform.position, Quaternion.identity);

                // エフェクトを２秒後に消す
               // Destroy(effect, 2.0f);
            }
            else
            {
                Debug.Log("HP" + objectHP);
                isDead = true;
                Destroy(other.gameObject);

                if (animator != null)
                {
                    animator.SetBool("isDown", true);
                }
                //GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
               // Destroy(effect2, 2.0f);
                // このスクリプトがついているオブジェクトを破壊する（thisは省略が可能）
                Destroy(this.gameObject,1.5f);

                sm.AddScore(scoreValue);

                // ボスの場合
                if (isBoss == true)
                {
                    // ボスの倒した数を加算する
                    gameManager.AddBossCount();
                }

                int randomKeyValue = Random.Range(0, 100);
                if (randomKeyValue < keyRate)
                {
                    GameObject keySpawn = GameObject.Find("KeySpawn");
                    if (keySpawn != null)
                    {
                        KeySpawnManager keySpawnManager = keySpawn.GetComponent<KeySpawnManager>();
                        keySpawnManager.SpawnKeyfromEnemy(transform);
                        return;
                    }
                }
                int itemNumber = Random.Range(0,100);

                if(itemPrefabs.Length != 0)
                { // （ポイント）pos.y + 0.6fのコードでアイテムの出現場所の「高さ」を調整しています。
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
                    {// itenMunberの数字によって、出るアイテムが変化する
                        Instantiate(itemPrefabs[2], new Vector3(pos.x, pos.y + itemHigh, pos.z), Quaternion.identity);
                    }
                    
                } 
                
               
            }
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
