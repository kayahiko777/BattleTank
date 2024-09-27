using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class TankMovment_X : MonoBehaviour
{
    private float turnInputValue;
    private  Rigidbody rb;
    public float moveSpeed;
    //サウンド
    public AudioClip[] sounds;
    private AudioSource audioSource;

    public GameObject[] cata;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //サウンド
       // audioSource = GetComponent<AudioSource>();
       // audioSource.clip = sounds[0];//アイドル音
       // audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            //audioSource.clip = sounds[1];
           // audioSource.Play();
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
           // audioSource.clip = sounds[0];
           // audioSource.Play();
        }

        //前進
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity += transform.forward * moveSpeed;

            float offset = Time.time * 1.2f;
            foreach(GameObject c in cata)
            {
                c.GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            }
        }
        //後退
        if(Input.GetKey(KeyCode.S))
        {
            rb.velocity -= transform.forward *moveSpeed;

            float offset = Time.time * 1.2f;

            foreach (GameObject c in cata)
            {
                c.GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            }
        }

        TankTurn();
    }
    //旋回
    void TankTurn()
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * Time.deltaTime * 50; //旋回速度
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
