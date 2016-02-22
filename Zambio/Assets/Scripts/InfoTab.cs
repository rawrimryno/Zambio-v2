using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoTab : MonoBehaviour {

    public GameObject infoTab;

    public bool active;

	void Start () {
        
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
        }
    }

    public void toggleInfo ()
    {
        infoTab.SetActive(active);
    }

}
