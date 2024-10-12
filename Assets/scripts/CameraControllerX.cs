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
        // ゲームスタート時はTPSモード
        tpsCMVC.Priority = 100;
        // TPSモード時はAim（照準器）をオフにする。
        aim.SetActive(false);
        // ゲーム開始時はFPSカメラをOFFにする
        fpsCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            // numの初期値は「-1」なので、Priorityは「-100」になる。
            // fpsのPriorityは「10」なので、今度はfpsモードになる。
            tpsCMVC.Priority = 100 * num;
            // Cボタンを押すごとにnumの値が「1」と「-1」に変化する
            num *= -1;
            if (tpsCMVC.Priority == -100)// FPSモードの時
            {
                // Aim（照準器）をオンにする
                aim.SetActive(true);
                // 砲塔の上下機能（Qボタン/Eボタン）を「オフ」にする
                turretController.enabled = false;

                tpsCam.enabled = false; // TPSカメラをOFFにする
                fpsCam.enabled = true; // FPSカメラをONにする
            }
            else// TPSモードの時
            {
                // Aim（照準器）をオフにする
                aim.SetActive(false);
                // 砲塔の上下機能（Qボタン/Eボタン）を「オン」にする
                turretController.enabled = true;

                tpsCam.enabled = true; // TPSカメラをONにする
                fpsCam.enabled = false; // FPSカメラをOFFにする
            }
        }
    }
}
