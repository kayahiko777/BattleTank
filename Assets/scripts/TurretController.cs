using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private Vector3 angle;
    public GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        angle = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            angle.x -= 0.2f;

            if(angle.x < -30)
            {
                angle.x = -30;
            }
            transform.eulerAngles = new Vector3(angle.x, head.transform.eulerAngles.y, 0);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            angle.x += 0.2f;

            if (angle.x > 0)
            {
                angle.x = 0;
            }

            transform.eulerAngles = new Vector3(angle.x, head.transform.eulerAngles.y, 0);
        }
    }
}
