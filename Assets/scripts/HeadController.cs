using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class HeadController : MonoBehaviour
{
    //–C“ƒ‚ÌŠp“x
    public GameObject turret;

    public CinemachineVirtualCamera tpsCMVC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        //–C“ƒ‚ÌŠp“x
        if (tpsCMVC.Priority == -100)
        {
            turret.transform.rotation = Quaternion.Euler(Camera.main.transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
    }
}
