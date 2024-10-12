using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControllerX : MonoBehaviour
{
    public CinemachineVirtualCamera tpsCMVC;
    public CinemachineVirtualCamera fpsCMVC;

    public GameObject aim;
    public TurretController turretController;

    private int num = -1;

    public Camera tpsCam;
    public Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        // �Q�[���X�^�[�g����TPS���[�h
        tpsCMVC.Priority = 100;
        // TPS���[�h����Aim�i�Ə���j���I�t�ɂ���B
        aim.SetActive(false);
        // �Q�[���J�n����FPS�J������OFF�ɂ���
        fpsCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            // num�̏����l�́u-1�v�Ȃ̂ŁAPriority�́u-100�v�ɂȂ�B
            // fps��Priority�́u10�v�Ȃ̂ŁA���x��fps���[�h�ɂȂ�B
            tpsCMVC.Priority = 100 * num;
            // C�{�^�����������Ƃ�num�̒l���u1�v�Ɓu-1�v�ɕω�����
            num *= -1;
            if (tpsCMVC.Priority == -100)// FPS���[�h�̎�
            {
                // Aim�i�Ə���j���I���ɂ���
                aim.SetActive(true);
                // �C���̏㉺�@�\�iQ�{�^��/E�{�^���j���u�I�t�v�ɂ���
                turretController.enabled = false;

                tpsCam.enabled = false; // TPS�J������OFF�ɂ���
                fpsCam.enabled = true; // FPS�J������ON�ɂ���
            }
            else// TPS���[�h�̎�
            {
                // Aim�i�Ə���j���I�t�ɂ���
                aim.SetActive(false);
                // �C���̏㉺�@�\�iQ�{�^��/E�{�^���j���u�I���v�ɂ���
                turretController.enabled = true;

                tpsCam.enabled = true; // TPS�J������ON�ɂ���
                fpsCam.enabled = false; // FPS�J������OFF�ɂ���
            }
        }
    }
}
