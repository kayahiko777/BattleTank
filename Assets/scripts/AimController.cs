using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    public Image aimImage;
    public GameObject aim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                // 照準器を赤色に変化させる。
                aimImage.color = Color.red;

                // aimの大きさを小さくする
                aim.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {
                // 照準器を白に戻す。
                aimImage.color = Color.white;

                // aimの大きさを元に戻す
                aim.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            aimImage.color = Color.white;
            aim.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
