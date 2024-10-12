using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    private CinemachineFollowZoom fpsFollowZoom;
    private float fov;

    // Start is called before the first frame update
    void Start()
    {
        fpsFollowZoom = GetComponent<CinemachineFollowZoom>();
        fov = fpsFollowZoom.m_MaxFOV;
    }

    // Update is called once per frame
    void Update()
    {
        // zoom up
        // こちらは「押している時」なので「GetKey」を使う（ポイント
        if (Input.GetKey(KeyCode.Q))
        {
            fov -= 0.5f;
            fov = Mathf.Clamp(fov, 3, 60); // fovの値を3?60の範囲に制限する
            fpsFollowZoom.m_MaxFOV = fov;
        }
        // zoom out（リセット）
        // こちらは「押した時」なので「GetKeyDown」を使う（ポイント
        else if (Input.GetKey(KeyCode.E))
        {
            fov = 60;
            fpsFollowZoom.m_MaxFOV = fov;
        }
    }
}
