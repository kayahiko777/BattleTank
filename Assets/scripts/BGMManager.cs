using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource mainBGMSource;        // ��ɗ����BGM�p��AudioSource
    public AudioSource areaBGMSource;        // ����̏ꏊ�ŗ����BGM�p��AudioSource
    public AudioSource windBGMSource;        // ����I�ɗ���镗�̉��p��AudioSource

    public AudioClip mainBGM;                // ��ɗ����BGM�N���b�v
    public AudioClip treeAreaBGM;            // �؂̋߂��ŗ����BGM�N���b�v
    public AudioClip windBGM;                // ���̉�BGM�N���b�v

    public Transform player;                 // �v���C���[��Transform
    public Transform tree;                   // �؂̈ʒu������Transform

    public float areaRadius = 10f;           // �؂̋߂���BGM�������͈́i���a�j
    public float windInterval = 30f;         // ���̉��������Ԋu�i�b�j

    private float windTimer;                 // ���̉��̍Đ����Ǘ�����^�C�}
    // Start is called before the first frame update
    void Start()
    {
        // �eBGM��AudioSource�ɃN���b�v��ݒ�
        mainBGMSource.clip = mainBGM;
        areaBGMSource.clip = treeAreaBGM;
        windBGMSource.clip = windBGM;
        // ��ɗ����BGM�����[�v�Đ�
        mainBGMSource.loop = true;
        mainBGMSource.Play();

        //�^�C�}�[������
        windTimer = windInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�Ɩ؂̋������v�Z
        float distanceToTree = Vector3.Distance(player.position, tree.position);
        // �؂̋߂��ɂ���ꍇ��BGM��؂�ւ���
        if (distanceToTree <= areaRadius)
        {
            if (!areaBGMSource.isPlaying)
            {
                areaBGMSource.Play();
                mainBGMSource.Pause(); // ���C��BGM���ꎞ��~
            }
        }
        else
        {
            if (!areaBGMSource.isPlaying)
            {
                areaBGMSource.Stop();
                mainBGMSource.UnPause();  // ���C��BGM���ĊJ
            }
        }

        windTimer -= Time.deltaTime;
        if(windTimer <= 0f)
        {
            windBGMSource.Play();
            windTimer = windInterval + windBGMSource.clip.length; // �Đ��Ԋu�����Z�b�g
        }
    }
}
