using UnityEngine;
using System.Collections;
using System;

public class AmmoScript : MonoBehaviour {
    private Rigidbody rb;

    public float spinFactor;

    // Called at the same time if it is in a sceneload, for all objects being loaded
    // Good to place calcs that are independent from other game objects here
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (Math.Abs(spinFactor) <= 0)
        {
            spinFactor = 15f;
        }
    }

	// Use this for initialization
	void Start () {
        rb.AddTorque(rb.mass * spinFactor * Vector3.up); 
    }
	
	// Update is called once per frame
	void Update () {

	}
    
    // Interesting,
    // FixedUpdate() AddTorque doesn't seem to work with NavMesh and NavAgent
    // 
    void FixedUpdate()
    {

    }

    void OnCollisionEnter( Collision cInfo)
    {
        if ( cInfo.transform.CompareTag("Enemy"))
        {
            Destroy(cInfo.gameObject);
        }
    }
}
