using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    GameControllerSingleton gc;
    NavAgentGoToTransform enemyNav;
    Rigidbody rb;

    private bool hasLeftSpawner = true;
    private bool init = false;
    private float yDisp = 0;

    public float pipeHeight = 5;



    void Awake()
    {
        Random.seed = (int)Time.realtimeSinceStartup;
    }

    // Use this for initialization
    void Start()
    {
        gc = GameControllerSingleton.get();
        enemyNav = GetComponent<NavAgentGoToTransform>();
        rb = GetComponent<Rigidbody>();
        acquirePlayer();
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnTriggerEnter(Collider oCol)
    {
        if (!init && oCol.CompareTag("Spawner"))
        {
            hasLeftSpawner = false;
            enemyNav.enabled = false;
        }
    }

    void OnTriggerStay(Collider oCol)
    {
        float randVal = Random.value * Mathf.PI;

        if (!hasLeftSpawner && oCol.CompareTag("Spawner"))
        {
            if (!init && yDisp < pipeHeight)
            {
                transform.position += new Vector3(0, 1, 0);
                yDisp += 1;
            }
            else
            {
                rb.AddForce(Mathf.Cos(randVal), 0, Mathf.Sin(randVal));
            }
        }
    }
    void OnTriggerExit(Collider oCol)
    {
        if (oCol.CompareTag("Spawner"))
        {
            hasLeftSpawner = true;
            init = true;
            enemyNav.enabled = true;
            acquirePlayer();
        }
    }

    void acquirePlayer()
    {
        enemyNav.target = gc.pc.transform;
    }
}