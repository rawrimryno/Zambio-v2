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

    private List<string> hasPowerUp;

    public Inventory myInventory
    {
        get; private set;
    }

    void Awake()
    {
        myInventory = GetComponent<Inventory>();
        hasPowerUp = new List<string>();
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        health = 20;
    }
    // Use this for initialization
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("HealthPanel").GetComponent<HealthPanel>();
        hpDisplay = GameObject.FindGameObjectWithTag("HealthStatusDisplay").GetComponent<HealthPanelDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Key->Button
        if (Input.GetKeyDown("q"))
        {
            int ammo = UI.bullet;
            UI.changeAmmo(++ammo);
            hpDisplay.setTextToAmmoName();
        }

        //Zach Added Below Cases
        if (Input.GetKeyDown("e"))
        {
            int ammo = UI.bullet;
            UI.changeAmmo(--ammo);
            hpDisplay.setTextToAmmoName();
        }
        //ShortCut Keys
        if (Input.GetKeyDown("1"))
        {
            int ammo = UI.bullet;
            UI.changeAmmo(1);
            hpDisplay.setTextToAmmoName();
        }
        if (Input.GetKeyDown("2"))
        {
            int ammo = UI.bullet;
            UI.changeAmmo(2);
            hpDisplay.setTextToAmmoName();
        }
        if (Input.GetKeyDown("3"))
        {
            int ammo = UI.bullet;
            UI.changeAmmo(3);
            hpDisplay.setTextToAmmoName();
        }
        if (Input.GetKeyDown("4"))
        {
            int ammo = UI.bullet;
            UI.changeAmmo(4);
            hpDisplay.setTextToAmmoName();
        }
        if (Input.GetKeyDown("5"))
        {
            int ammo = UI.bullet;
            UI.changeAmmo(5);
            hpDisplay.setTextToAmmoName();
        }

    }

    // TRIGGERS!
    void OnTriggerEnter(Collider tColl)
    {
        if (tColl.CompareTag("PickUp"))
        {
            PowerUp thisPowerUp = tColl.GetComponent<PowerUp>();
            
            //Health Check for Mushrooms
            // finalHealth < 20
            // Gain Health
            if (health + thisPowerUp.numQtrHearts < 20)
            {
                health += thisPowerUp.numQtrHearts;
                UI.getHealth();
            }
            
            // finalHealth < 0
            // Rancid Mushroom
            else if (health + thisPowerUp.numQtrHearts < 0)
            {
                health = 0;
                UI.getHealth();
                deathSequence();
            }
            
            // finalHealth >= 20
            else // targetHealth >= 20
            {
                health = 20;
                UI.getHealth();
            }

            //Player already-has-checks for proper PowerUp placement
            if (thisPowerUp.isFire || thisPowerUp.isMetal)
            {
                if (hasPowerUp.Contains(thisPowerUp.name))
                {
                    // Already has it applied?  Put it in the inventory for safe keeping
                    myInventory.AddPower(thisPowerUp);
                }
                else {
                    // Apply to player
                    hasPowerUp.Add(thisPowerUp.name);
                }
            }

            //Set the other thing to false, destroy when able
            tColl.gameObject.SetActive(false);
            Destroy(tColl.gameObject);
        }
    }
    void deathSequence()
    {
        //Game Over

    }
}