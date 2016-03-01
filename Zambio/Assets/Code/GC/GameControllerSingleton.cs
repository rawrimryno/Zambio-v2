using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;
// Maintainer/Listener GameController
public class GameControllerSingleton : ScriptableObject
{
    private static GameControllerSingleton _instance;

    //public Dictionary<string, PowerUpDesc> powerUpData;
    public Dictionary<string, PowerUpDesc> powerUpData;
    public Dictionary<int, PowerUpDesc> powerUpByID;
    public int numPowerUps { get; private set; }
    //public Dictionary<string, AmmoDesc> ammoData;
    public Dictionary<string, AmmoDesc> ammoData;
    public Dictionary<int, AmmoDesc> ammoByID { get; private set; }
    public int numAmmo
    {
        get; private set;
    }
    public PlayerController pc;
    bool hasPC = false;

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
        DontDestroyOnLoad(this);
        powerUpData = new Dictionary<string, PowerUpDesc>();
        powerUpByID = new Dictionary<int, PowerUpDesc>();
        ammoData = new Dictionary<string, AmmoDesc>();
        ammoByID = new Dictionary<int, AmmoDesc>();
        // Do initial load up stuff
    }

    // Update is called once per frame
    public void Update()
    {
        if (!hasPC)
        {
            pc = FindObjectOfType<PlayerController>();
        }
        // Debug.Log("GCS Updating");
    }

    public string getAmmoDisplayNamefromID(int ammoID)
    {
        string rName;
        AmmoDesc tempAmmoDesc;

        if (ammoByID.TryGetValue(ammoID, out tempAmmoDesc))
        {
            rName = tempAmmoDesc.dName;
        }

        else
        {
            rName = "null";
        }
        return rName;
    }
    public void loadTexts(TextAsset powerUpFile, TextAsset ammoFile)
    {
        int i = 0;
        string shortName, dispName, desc;
        StringReader sr = new StringReader(powerUpFile.text);
        while ((shortName = sr.ReadLine()) != null && shortName[0] != '~')
        {
            PowerUpDesc tempPowerUp = new PowerUpDesc();
            tempPowerUp.setSName(shortName);
            if ((dispName = sr.ReadLine()) != null)
                tempPowerUp.setDName(dispName);
            if ((desc = sr.ReadLine()) != null)
                tempPowerUp.setDesc(desc);
            tempPowerUp.setID( Convert.ToInt32(sr.ReadLine()) );
            tempPowerUp.setSprite(null);
            TagAdder.AddTag(shortName);
            powerUpData.Add(shortName, tempPowerUp);
            powerUpByID.Add( tempPowerUp.ID, tempPowerUp);
            //Debug.Log(i);
            //powerUpData.Add(tempPowerUp.sName, tempPowerUp);
        }

        StringReader asr = new StringReader(ammoFile.text);
        while ((shortName = asr.ReadLine()) != null)
        {
            AmmoDesc tempAmmoDesc = new AmmoDesc();
            tempAmmoDesc.setSName(shortName);
            if ((dispName = asr.ReadLine()) != null)
                tempAmmoDesc.setDName(dispName);
            if ((desc = asr.ReadLine()) != null)
                tempAmmoDesc.setDesc(desc);
            tempAmmoDesc.setID(i++);
            tempAmmoDesc.setSprite(null);
            //            ammoData.Add(tempAmmoDesc.sName, tempAmmoDesc);
            TagAdder.AddTag(shortName);
            ammoData.Add(shortName, tempAmmoDesc);
            ammoByID.Add(i - 1, tempAmmoDesc);

            // Debug.Log("Added " + tempAmmoDesc.dName + " at index " + (i - 1));

        }
        // Debug.Log("Tried to loadAmmo and PowerUps");
    }
}