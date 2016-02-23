using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

// Worker GameController
public class GameController : MonoBehaviour
{
    GameData data;
    GameControllerSingleton gc;
    private bool UIenabled = false;

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {

        /* This If and Else are for maintaining the gamecontroller through additional scenes.
        */
        if (gc == null)
        {
            DontDestroyOnLoad(this);
            gc = GameControllerSingleton.get();
        }
        else
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        gc.Update();
        // UI Toggle
        if (Input.GetButtonDown("toggleUI"))
        {
            if (UIenabled)
            {
                SceneManager.UnloadScene("UI");
                UIenabled = false;
            }
            else
            {
                SceneManager.LoadScene("UI", LoadSceneMode.Additive);
                UIenabled = true;
            }
        }
    }
}

[Serializable]
class GameData
{
    public float PlayedTime { get; private set; }
    public float RoundTime { get; private set; }
    public int Round { get; private set; }
    public enum GameState
    {
        STATE_STORY,             // We are doing some story stuff
        STATE_DEMO,              // We are in Demo mode
        STATE_WAVE_IN_PROGRESS,  // There is a wave in progress
        STATE_CHILL              // We are between waves, no enemies to worry about
                                 // More States
    };
    // FSM to handle with game flow
    public GameState State { get; private set; }
}