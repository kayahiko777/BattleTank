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
                // �Ə����ԐF�ɕω�������B
                aimImage.color = Color.red;

                // aim�̑傫��������������
                aim.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {
                // �Ə���𔒂ɖ߂��B
                aimImage.color = Color.white;

                // aim�̑傫�������ɖ߂�
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
