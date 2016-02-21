using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour
{
    GameData data;
    GameControllerSingleton gc;

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