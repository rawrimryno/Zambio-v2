using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    HealthPanel UI;
    HealthPanelDisplay hpDisplay;
    // Use this when you want to increase ammo or add Powerups already applied to character
    public int health { get; private set; }

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            int ammo = UI.bullet;
            UI.changeAmmo(--ammo);
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
            tColl.gameObject.SetActive(false);
            Destroy(tColl.gameObject);
        }
    }
    void deathSequence()
    {
        //Game Over

    }
}