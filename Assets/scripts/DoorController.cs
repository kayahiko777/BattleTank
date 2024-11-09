using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int requiredKeys = 3;
    private int currentKeys = 0;


    public void AddKey()
    {
        currentKeys++;
        Debug.Log("鍵を取得しました");

        if(currentKeys >= requiredKeys)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        Debug.Log("扉が開きました");
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
