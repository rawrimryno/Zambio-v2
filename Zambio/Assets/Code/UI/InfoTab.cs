using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoTab : MonoBehaviour {

    public GameObject canvas;
    public GameObject infoTab;
    public GameObject healthPanel;
    public GameObject compasPanel;
    public GameObject bossBar;

    public bool active;

	void Start () {
        RectTransform iTrC = infoTab.GetComponent<RectTransform>();
        RectTransform hPrC = healthPanel.GetComponent<RectTransform>();
        RectTransform cPrC = compasPanel.GetComponent<RectTransform>();
        RectTransform bBrC = bossBar.GetComponent<RectTransform>();
        scaleItems();
        toggleInfo();
    }
	
	void Update () {
        if (Input.GetKeyDown("tab"))
        {
            if (active)
            {
                active = false;
            }
            else
            {
                active = true;
            }
            toggleInfo();
            scaleItems();
        }
    }

    public void toggleInfo ()
    {
        infoTab.SetActive(active);
    }

    public void scaleItems ()
    {
        
    }

}
