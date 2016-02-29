using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthPanelDisplay : MonoBehaviour {
    Text myTextBox;
    GameControllerSingleton gc;
    public HealthPanel myParent;

    void Awake()
    {
        myTextBox = GetComponent<Text>();
    }
	// Use this for initialization
	void Start () {
        gc = GameControllerSingleton.get();
        AmmoDesc tempDesc = new AmmoDesc();
        if ( gc.pc.myInventory.powerUpContents.Contains)
        myTextBox.text = gc.ammoData[0].dName;
        //myTextBox.text = gc.powerUpData[0].dName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void setTextToAmmoName()
    {
        myTextBox.text = gc.ammoData[myParent.bullet-1].dName;
    }
}
