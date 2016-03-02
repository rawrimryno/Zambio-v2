using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    HealthPanel UI;
    HealthPanelDisplay hpDisplay;
    // Use this when you want to increase ammo or add Powerups already applied to character
    public Inventory myInventory
    {
        get; private set;
    }

    void Awake()
    {
        SceneManager.LoadScene("UI",LoadSceneMode.Additive);
    }
	// Use this for initialization
	void Start () {
        UI = GameObject.FindGameObjectWithTag("HealthPanel").GetComponent<HealthPanel>();
        hpDisplay = GameObject.FindGameObjectWithTag("HealthStatusDisplay").GetComponent<HealthPanelDisplay>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("q"))
        {
            int ammo = UI.bullet;
            UI.changeAmmo(--ammo);
            hpDisplay.setTextToAmmoName();
        }

        //Zach Added Below Cases
        if (Input.GetKeyDown("e"))
        {
            int ammo = UI.bullet;
            UI.changeAmmo(++ammo);
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

}