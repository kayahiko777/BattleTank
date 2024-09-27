using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int destroyBossCount;
    public int clearBossCount;
    public TextMeshProUGUI bossCountText;
    // Start is called before the first frame update
    void Start()
    {
        bossCountText.text = destroyBossCount+ " / " + clearBossCount;
    }
    
    public void AddBossCount()
    {
        //倒したボスの数をカウント
        destroyBossCount++;

        //画面の表示を更新
        bossCountText.text = destroyBossCount + " / " + clearBossCount;

        //クリア目標に到達したかチェック
        if( destroyBossCount >= clearBossCount )
        {
            //クリアできていたらクリア画面にする
            Debug.Log("GameClear");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
