using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    GameControllerSingleton gc;
    NavAgentGoToTransform enemyNav;

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
        enemyNav.target = gc.pc.transform;
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
        }
    }

    void OnTriggerStay(Collider oCol)
    {
        float randVal = Random.value*Mathf.PI;

        if (!hasLeftSpawner && !init && yDisp < pipeHeight)
        {
            transform.position += new Vector3(0, 1, 0);
            yDisp += 1;
        }
        else
        {
            transform.position += new Vector3(Mathf.Cos(randVal), 0, Mathf.Sin(randVal));

        }
    }

}
