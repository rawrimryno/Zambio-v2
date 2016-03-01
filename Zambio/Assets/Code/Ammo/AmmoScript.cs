using UnityEngine;
using System.Collections;
using System;

public class AmmoScript : MonoBehaviour
{
    private GameControllerSingleton gc;
    private Rigidbody rb;
    public bool isLit = false;  // Was the ammoshot out of someone with fireFlower?
    private int hitCount = 1;   // Min 1
    public int maxHits;
    public int myID;

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
    void Start()
    {
        gc = GameControllerSingleton.get();
        rb.AddTorque(rb.mass * spinFactor * Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Interesting,
    // FixedUpdate() AddTorque doesn't seem to work with NavMesh and NavAgent
    // 
    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision cInfo)
    {
        AmmoDesc thisAmmo = new AmmoDesc();
        if (cInfo.transform.CompareTag("Enemy"))
        {
            cInfo.gameObject.SetActive(false);
            Destroy(cInfo.gameObject);
            // This may be left for ammo set off with fireFlower powerup
            //rb.AddExplosionForce(7.4f, new Vector3(0, 1, 0), 2);
            if (gc.ammoByID.TryGetValue(myID, out thisAmmo))
            {
                if (thisAmmo.sName == "greenShell")
                {
                    if (!isLit)
                    {
                        gameObject.SetActive(false);
                        Destroy(this);
                    }
                    // ELSE EXPLODE!
                }
                else if (thisAmmo.sName == "redShell")
                {
                    if (!isLit)
                    {
                        if (hitCount < maxHits)
                            hitCount++;
                        else
                        {
                            gameObject.SetActive(false);
                            Destroy(this);
                        }
                    }
                }
            }
        }
    }

    void updateTag(AmmoScript go)
    {
        AmmoDesc tempDesc = new AmmoDesc();

        // Object name is important
        // If Object name isn't on poweruplist, set ID to -1
        if (gc.ammoData.TryGetValue(gameObject.name, out tempDesc))
        {
            myID = tempDesc.ID;
        }
    }

    //IEnumerator destroySelf( )
}
