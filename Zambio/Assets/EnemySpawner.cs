using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject Enemy;
    public float rate;
    public float level;
    void Start()
    {
            InvokeRepeating("Spawn",1,rate);   
    }

    void Spawn()
    { 
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}