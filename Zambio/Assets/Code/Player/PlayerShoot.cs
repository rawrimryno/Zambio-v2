using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public GameObject ammo;
    public float bulletSpeed;
    public float rateOfFire;
    private float timer;
    private Rigidbody projectile;

	// Use this for initialization
	void Start () {
	    if (bulletSpeed == 0)
        {
            bulletSpeed = 20.0f;
        }
        if (rateOfFire == 0)
        {
            rateOfFire = 1.0f;
        }
        timer = rateOfFire;
        projectile = ammo.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && rateOfFire <= 0 && Time.timeScale!= 0f)
        {
            Rigidbody clone;
            clone = Instantiate(projectile, (transform.position), transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection((Vector3.forward) * bulletSpeed);
            rateOfFire = timer;
        }
        else
        {
            rateOfFire -= Time.deltaTime;
        }
	}
}
