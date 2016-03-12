using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public GameObject[] ammo;
    public float bulletSpeed;
    public float rateOfFire;
    private float timer;
    private Rigidbody projectile;
    private int ammoNum;
    private HealthPanel UI;
    private HealthPanelDisplay hpDisplay;

	// Use this for initialization
	void Start () {
        UI = GameObject.FindGameObjectWithTag("HealthPanel").GetComponent<HealthPanel>();
        hpDisplay = GameObject.FindGameObjectWithTag("HealthStatusDisplay").GetComponent<HealthPanelDisplay>();
        ammoNum = UI.bullet;
        if (bulletSpeed == 0)
        {
            bulletSpeed = 20.0f;
        }
        if (rateOfFire == 0)
        {
            rateOfFire = 1.0f;
        }
        timer = rateOfFire;
        projectile = ammo[0].GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        ammoNum = UI.bullet-1;
        if (Input.GetButtonDown("Fire1") && rateOfFire <= 0 && Time.timeScale!= 0f)
        {
            Rigidbody clone;
            projectile = ammo[ammoNum].GetComponent<Rigidbody>();
            clone = Instantiate(projectile, (transform.position), transform.rotation) as Rigidbody;
            //clone = Instantiate(projectile, (transform.position), transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection((Vector3.forward) * bulletSpeed);
            rateOfFire = timer;
        }
        else
        {
            rateOfFire -= Time.deltaTime;
        }
	}
}
