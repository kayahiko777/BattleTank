using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject effectPrefab;

    public GameObject effectPrefab2; // 2種類目のエフェクトを入れるための箱
    public int objectHP;
    // このメソッドはコライダー同士がぶつかった瞬間に呼び出される
    private void OnTriggerEnter(Collider other)
    {
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
                GameObject effect = Instantiate(effectPrefab,other.transform.position, Quaternion.identity);

                // エフェクトを２秒後に消す
                Destroy(effect, 2.0f);
            }
            else
            {
                Destroy(other.gameObject);

                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);
                // このスクリプトがついているオブジェクトを破壊する（thisは省略が可能）
                Destroy(this.gameObject);
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
