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
    }

}