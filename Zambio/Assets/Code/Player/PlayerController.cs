﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    HealthPanel UI;
    HealthPanelDisplay hpDisplay;
    // Use this when you want to increase ammo or add Powerups already applied to character
    public int health { get; private set; }
    private int ammo;
    private List<PowerUp> myPowerUps;

    public Inventory myInventory
    {
        get; private set;
    }

    void Awake()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        health = 20;
    }
    // Use this for initialization
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("HealthPanel").GetComponent<HealthPanel>();
        hpDisplay = GameObject.FindGameObjectWithTag("HealthStatusDisplay").GetComponent<HealthPanelDisplay>();
        ammo = UI.bullet;
        myInventory = GetComponent<Inventory>();
        myPowerUps = new List<PowerUp>();
    }

    // Update is called once per frame
    void Update()
    {
        ammo = UI.bullet;

        if (Input.GetButtonDown("PreviousAmmo"))
        {
            if (ammo-1 < 1)
                ammo = 6;
            UI.changeAmmo(--ammo);
            hpDisplay.setTextToAmmoName();
        }
        if (Input.GetButtonDown("NextAmmo"))
        {
            if (ammo+1 > 5)
                ammo = 0;
            UI.changeAmmo(++ammo);
            hpDisplay.setTextToAmmoName();
        }
        //switch case impossible because of specific button press -Ryan
        //ShortCut Keys
        if (Input.GetKeyDown("1"))
        {
            UI.changeAmmo(1);
            hpDisplay.setTextToAmmoName();
        }
        if (Input.GetKeyDown("2"))
        {
            UI.changeAmmo(2);
            hpDisplay.setTextToAmmoName();
        }
        if (Input.GetKeyDown("3"))
        {
            UI.changeAmmo(3);
            hpDisplay.setTextToAmmoName();
        }
        if (Input.GetKeyDown("4"))
        {
            UI.changeAmmo(4);
            hpDisplay.setTextToAmmoName();
        }
        if (Input.GetKeyDown("5"))
        {
            UI.changeAmmo(5);
            hpDisplay.setTextToAmmoName();
        }
        
    }
    void OnTriggerEnter(Collider tColl)
    {
        if (tColl.CompareTag("PickUp"))
        {
            PowerUp thisPowerUp = tColl.GetComponent<PowerUp>();
            // Gain Health
            if (health + thisPowerUp.numQtrHearts < 20)
            {
                health += thisPowerUp.numQtrHearts;
                UI.getHealth();
            }
            else if (health + thisPowerUp.numQtrHearts < 0) // Rancid Mushroom
            {
                health = 0;
                UI.getHealth();
                deathSequence();
            }
            else // targetHealth >= 20
            {
                health = 20;
                UI.getHealth();
            }

            // Check powerup applied, add to to inventory if not, else add to powerup applied
            if ( thisPowerUp.isFire || thisPowerUp.isMetal )
            {
                if ( myPowerUps.Contains(thisPowerUp) )
                {
                    myInventory.AddPower(thisPowerUp);
                }
                myPowerUps.Add(thisPowerUp);                
            }

            tColl.gameObject.SetActive(false);
            Destroy(tColl.gameObject);
        }
    }

    public void adjustHealth(int amt)
    {
        health += amt;
    }
    void deathSequence()
    {
        //Game Over

    }
}