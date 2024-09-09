using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    private GameObject target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Tank");
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            transform.position = target.transform.position + offset;
        }
    }
}
