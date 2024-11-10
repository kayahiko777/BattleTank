using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource mainBGMSource;        // 常に流れるBGM用のAudioSource
    public AudioSource areaBGMSource;        // 特定の場所で流れるBGM用のAudioSource
    public AudioSource windBGMSource;        // 定期的に流れる風の音用のAudioSource

    public AudioClip mainBGM;                // 常に流れるBGMクリップ
    public AudioClip treeAreaBGM;            // 木の近くで流れるBGMクリップ
    public AudioClip windBGM;                // 風の音BGMクリップ

    public Transform player;                 // プレイヤーのTransform
    public Transform tree;                   // 木の位置を示すTransform

    public float areaRadius = 10f;           // 木の近くでBGMが流れる範囲（半径）
    public float windInterval = 30f;         // 風の音が流れる間隔（秒）

    private float windTimer;                 // 風の音の再生を管理するタイマ
    // Start is called before the first frame update
    void Start()
    {
        // 各BGMのAudioSourceにクリップを設定
        mainBGMSource.clip = mainBGM;
        areaBGMSource.clip = treeAreaBGM;
        windBGMSource.clip = windBGM;
        // 常に流れるBGMをループ再生
        mainBGMSource.loop = true;
        mainBGMSource.Play();

        //タイマー初期化
        windTimer = windInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーと木の距離を計算
        float distanceToTree = Vector3.Distance(player.position, tree.position);
        // 木の近くにいる場合にBGMを切り替える
        if (distanceToTree <= areaRadius)
        {
            if (!areaBGMSource.isPlaying)
            {
                areaBGMSource.Play();
                mainBGMSource.Pause(); // メインBGMを一時停止
            }
        }
        else
        {
            if (!areaBGMSource.isPlaying)
            {
                areaBGMSource.Stop();
                mainBGMSource.UnPause();  // メインBGMを再開
            }
        }

        windTimer -= Time.deltaTime;
        if(windTimer <= 0f)
        {
            windBGMSource.Play();
            windTimer = windInterval + windBGMSource.clip.length; // 再生間隔をリセット
        }
    }
}
