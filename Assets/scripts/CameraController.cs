using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera fpsCamera;

    // �����l��?�P
    private int num = -1;
    // Start is called before the first frame update
    void Start()
    {
        // FPS�J������depth�̏����l���u?�P�v�ɐݒ�iMain�J�������u�O�v�Ȃ̂ŁA�ŏ���Main�J�������D��
        fpsCamera.depth = num;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            // C�{�^�����������ƂɁAnum�̒l���u�P�v�Ɓu?�P�v�ɕω�����i�e�N�j�b�N�j
            num *= -1;

            // depth���u�P�v�̎��E�E�E��FPS�J�������D��
            // depth���u?�P�v�̎��E�E�E��Main�J�������D��
            fpsCamera.depth = num;
        }
    }
}
