using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Tank");

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            // target�̈ʒu��ړI�n�ɐݒ肷��B
            agent.destination = target.transform.position;
        }
    }
}
