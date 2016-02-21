using UnityEngine;
using System.Collections;

public class GameControllerSingleton : ScriptableObject {
    private static GameControllerSingleton _instance;
	// Use this for initialization

    public static GameControllerSingleton get()
    {
        if (_instance == null)
        {
            _instance = ScriptableObject.CreateInstance<GameControllerSingleton>();
            _instance.Start();
        }
        return _instance;
    }
	

    void Start()
    {
        // Do initial load up stuff
    }

	// Update is called once per frame
	public void Update () {
	
	}
}
