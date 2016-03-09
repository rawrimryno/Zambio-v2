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

            if (thisPowerUp.isFire)
            {
                hasPowerUp.Add("Fire");
            }
            if (thisPowerUp.isMetal)
            {
                hasPowerUp.Add("Metal");
            }

            tColl.gameObject.SetActive(false);
            Destroy(tColl.gameObject);
        }
    }
    void deathSequence()
    {
        //Game Over

    }
}