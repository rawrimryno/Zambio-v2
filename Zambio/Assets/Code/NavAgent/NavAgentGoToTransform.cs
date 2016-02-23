﻿using UnityEngine;
using System.Collections;

public class NavAgentGoToTransform : MonoBehaviour
{

    public Transform target;
    NavMeshAgent agent;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            transform.LookAt(target);
        }
    }
}
