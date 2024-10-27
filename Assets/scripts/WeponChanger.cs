using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponChanger : MonoBehaviour
{
    public GameObject[] weponCameras;
    public GameObject[] rawImages;
    public int weponIndex;
    public float whiileRange;
    // Start is called before the first frame update
    void Start()
    {
        ChangeWepon();
    }

    // Update is called once per frame
    void Update()
    {
        float whiile = Input.mouseScrollDelta.y;
        if (Mathf.Abs(whiile) > whiileRange)
        {
            //weponIndex=0 % weponCameras.Length = 2�������ꍇ�]���0
            //weponIndex=1 % weponCameras.Length = 2�������ꍇ�]���1
            //weponIndex=2 % weponCameras.Length = 2�������ꍇ�]���0
            weponIndex = ++weponIndex % weponCameras.Length;
            ChangeWepon();
        }
    }

    private void ChangeWepon()
    {
        //weponIndex�̓����ԍ��̔z��̕����UI�ɕ\������
        for (int i = 0; i < weponCameras.Length; i++)
        {
            weponCameras[i].SetActive(false);
            rawImages[i].SetActive(false);
        }
        weponCameras[weponIndex].SetActive(true);
        rawImages[weponIndex].SetActive(true);
    }
}
