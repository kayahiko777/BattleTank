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
        // ������́u�����Ă��鎞�v�Ȃ̂ŁuGetKey�v���g���i�|�C���g
        if (Input.GetKey(KeyCode.Q))
        {
            fov -= 0.5f;
            fov = Mathf.Clamp(fov, 3, 60); // fov�̒l��3?60�͈̔͂ɐ�������
            fpsFollowZoom.m_MaxFOV = fov;
        }
        // zoom out�i���Z�b�g�j
        // ������́u���������v�Ȃ̂ŁuGetKeyDown�v���g���i�|�C���g
        else if (Input.GetKey(KeyCode.E))
        {
            fov = 60;
            fpsFollowZoom.m_MaxFOV = fov;
        }
    }
}
