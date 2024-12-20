using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponChanger : MonoBehaviour
{
    public GameObject[] weponCameras;
    public GameObject[] rawImages;
    public GameObject[] weapons;
    public int weponIndex;
    public float whiileRange;

    public int currentWeaponNo;

    [SerializeField]
    private PlayerController player;
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
            //weponIndex=0 % weponCameras.Length = 2だった場合余りは0
            //weponIndex=1 % weponCameras.Length = 2だった場合余りは1
            //weponIndex=2 % weponCameras.Length = 2だった場合余りは0
            weponIndex = ++weponIndex % weponCameras.Length;
            ChangeWepon();
        }
    }

    private void ChangeWepon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        // 現在の武器オブジェクトをアクティブ化
        weapons[weponIndex].SetActive(true);
        Debug.Log("ピストルに切り替え");
        //weponIndexの同じ番号の配列の武器をUIに表示する
        for (int i = 0; i < weponCameras.Length; i++)
        {
            weponCameras[i].SetActive(false);
            rawImages[i].SetActive(false);
        }
        weponCameras[weponIndex].SetActive(true);
        rawImages[weponIndex].SetActive(true);

        currentWeaponNo = weponIndex;

        Debug.Log("武器交換");

    }
}
