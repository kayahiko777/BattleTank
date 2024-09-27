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
        //�|�����{�X�̐����J�E���g
        destroyBossCount++;

        //��ʂ̕\�����X�V
        bossCountText.text = destroyBossCount + " / " + clearBossCount;

        //�N���A�ڕW�ɓ��B�������`�F�b�N
        if( destroyBossCount >= clearBossCount )
        {
            //�N���A�ł��Ă�����N���A��ʂɂ���
            Debug.Log("GameClear");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
