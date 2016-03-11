using UnityEngine;
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
    int ammo = 0;

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
        ammo = UI.bullet;
        // TODO: Key->Button
        if (Input.GetKeyDown("q"))
        {
            UI.changeAmmo(++ammo);
            hpDisplay.setTextToAmmoName();
        }

        //Zach Added Below Cases
        if (Input.GetKeyDown("e"))
        {
            UI.changeAmmo(--ammo);
            hpDisplay.setTextToAmmoName();
        }

        if (Input.GetButtonDown("PreviousAmmo"))
        {
            if (ammo-1 < 1)
                ammo = 6;
            UI.changeAmmo(ammo--);
            hpDisplay.setTextToAmmoName();
        }
        else if (Input.GetButtonDown("NextAmmo"))
        {
            if (ammo+1 > 5)
                ammo = 0;
            UI.changeAmmo(ammo++);
            hpDisplay.setTextToAmmoName();
        }
        //switch case impossible because of specific button press -Ryan

        //ShortCut Keys
        // Added Else so they can't change to both at the same time
        // Same for the previous and Next above
        if (Input.GetKeyDown("1"))
        {
            UI.changeAmmo(1);
            hpDisplay.setTextToAmmoName();
        }
        else if (Input.GetKeyDown("2"))
        {
            UI.changeAmmo(2);
            hpDisplay.setTextToAmmoName();
        }
        else if (Input.GetKeyDown("3"))
        {
            UI.changeAmmo(3);
            hpDisplay.setTextToAmmoName();
        }
        else if (Input.GetKeyDown("4"))
        {
            UI.changeAmmo(4);
            hpDisplay.setTextToAmmoName();
        }
        else if (Input.GetKeyDown("5"))
        {
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