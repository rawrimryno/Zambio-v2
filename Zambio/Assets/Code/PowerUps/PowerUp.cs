using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp : MonoBehaviour
{
    public int numQtrHearts;    // All Powerups can give hearts
    private short affectVector; // Yeah, I'm doing it
    public int defenseModifier; // But just in case I don't pull it off, Metal Mario
    public bool isFire;         // Fire Flower
    public bool isFeather;      // It's a feather, isn't it?
    public bool isMetal;
    public int myPowerUpID;     // Pretty sure we'll need this.. don't quote me
    // All PowerUps give BigManMode which allows Better Jump?


    GameControllerSingleton gc;
    PowerUpDesc tempDesc;

    bool init = false;
    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        gc = GameControllerSingleton.get();
    }

    // Update is called once per frame
    void Update()
    {
        if (!init)
        {
            updateTag(this);
            init = true;
        }

    }

    void updateTag(PowerUp go)
    {
        tempDesc = new PowerUpDesc();

        // Object name is important
        // If Object name isn't on poweruplist, set ID to -1
        if (gc.powerUpData.TryGetValue(gameObject.name, out tempDesc))
        {
            myPowerUpID = tempDesc.ID;
        }
    }
}


public class PowerUpDesc
{
    public int ID { get; private set; }
    public string desc { get; private set; }
    public string sName { get; private set; }
    public string dName { get; private set; }
    public Sprite sprite { get; private set; }

    public bool setID(int id)
    {
        ID = id;
        return true;
    }
    public bool setSName(string stringName)
    {
        sName = stringName;
        return true;
    }
    public bool setDName(string displayName)
    {
        dName = displayName;
        return true;
    }
    public bool setDesc(string description)
    {
        desc = description;
        return true;
    }
    public bool setSprite(Sprite powerUpSprite)
    {
        sprite = powerUpSprite;
        return true;
    }

}
