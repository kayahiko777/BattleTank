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
    //�T�E���h
    public AudioClip[] sounds;
    private AudioSource audioSource;

    public GameObject[] cata;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //�T�E���h
       // audioSource = GetComponent<AudioSource>();
       // audioSource.clip = sounds[0];//�A�C�h����
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

        //�O�i
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity += transform.forward * moveSpeed;

            float offset = Time.time * 1.2f;
            foreach(GameObject c in cata)
            {
                c.GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            }
        }
        //���
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
    //����
    void TankTurn()
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * Time.deltaTime * 50; //���񑬓x
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
