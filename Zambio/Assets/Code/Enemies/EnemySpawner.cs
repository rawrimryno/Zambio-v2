using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject Enemy;
    void Start()
    {
        InvokeRepeating("Spawn",1,3);   
    }

    void Spawn()
    { 
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}