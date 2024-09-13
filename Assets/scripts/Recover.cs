using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour
{
    private Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot = transform.eulerAngles;

        // Rボタンを押すと起き上がる。
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.eulerAngles = new Vector3(0, rot.y, 0);
        }
    }
}
