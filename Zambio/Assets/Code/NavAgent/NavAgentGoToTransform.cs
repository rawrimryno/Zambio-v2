﻿using UnityEngine;
using System.Collections;

public class NavAgentGoToTransform : MonoBehaviour
{

    public Transform target;
    NavMeshAgent agent;
    private float lookRatio = 1;
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
            if (Time.time % lookRatio >= 9f / 10f * lookRatio)
            {
                agent.SetDestination(target.position);
                transform.LookAt(target);
            }
        }
    }
}
