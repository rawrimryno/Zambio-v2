using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp : MonoBehaviour
{
    public int numQtrHearts;    // All Powerups can give hearts
    private short affectVector; // Yeah, I'm doing it
    public int defenseModifier; // But just in case I don't pull it off, Metal Mario
    public bool isFire;         // Fire Flower
    public bool isMetal;      // It's a metalMario, isn't it?
    public int myPowerUpID
    {
        get; private set;
    }                           // Pretty sure we'll need this.. don't quote me

    GameControllerSingleton gc;
    // All PowerUps give BigManMode which allows Better Jump?
    PowerUpDesc tempDesc;

    void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        gc = GameControllerSingleton.get();
        if (gc.powerUpData.ContainsKey(gameObject.tag))
        {
            tempDesc = new PowerUpDesc();
            gc.powerUpData.TryGetValue(gameObject.tag, out tempDesc);
            myPowerUpID = tempDesc.ID;
        }
    }

    // Update is called once per frame
    void Update()
    {

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
