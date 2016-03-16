﻿using UnityEngine;
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
    public Dictionary<int, AmmoDesc> ammoByID;
    public int numAmmo
    {
        get; private set;
    }
    public PlayerController pc;

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

    void Awake()
    {

    }

    void Start()
    {
        powerUpData = new Dictionary<string, PowerUpDesc>();
        powerUpByID = new Dictionary<int, PowerUpDesc>();
        ammoData = new Dictionary<string, AmmoDesc>();
        ammoByID = new Dictionary<int, AmmoDesc>();

        pc = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    public void Update()
    {
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
    public void loadTexts(TextAsset powerUpFile, TextAsset ammoFile, Sprite[] ammoSpr, Sprite[] powerUpSpr, GameObject[] ammoPrefab, GameObject[] powerUpPrefab)
    {
        int i = 0, id;
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

            id = Convert.ToInt32(sr.ReadLine());
            tempPowerUp.setID(id);

            powerUpData.Add(shortName, tempPowerUp);
            powerUpByID.Add(id, tempPowerUp);
            tempPowerUp.setSprite(id, powerUpSpr[id]);
            tempPowerUp.setPrefab(id, powerUpPrefab[id]);
            //Debug.Log(i);

        }
        i = 0;
        // AMMO SECTION
        StringReader asr = new StringReader(ammoFile.text);
        while ((shortName = asr.ReadLine()) != null)
        {
            AmmoDesc tempAmmoDesc = new AmmoDesc();
            tempAmmoDesc.setSName(shortName);
            if ((dispName = asr.ReadLine()) != null)
                tempAmmoDesc.setDName(dispName);
            if ((desc = asr.ReadLine()) != null)
                tempAmmoDesc.setDesc(desc);
            tempAmmoDesc.setID(i);
            //            ammoData.Add(tempAmmoDesc.sName, tempAmmoDesc);
            ammoData.Add(shortName, tempAmmoDesc);
            ammoByID.Add(i, tempAmmoDesc);
            tempAmmoDesc.setSprite(i, ammoSpr[i]);
            tempAmmoDesc.setPrefab(i, ammoPrefab[i]);
            i++;

            //Debug.Log("Added " + tempAmmoDesc.dName + " at index " + (i - 1));

        }
        numAmmo = i;
        // Debug.Log("Tried to loadAmmo and PowerUps");
    }

    // Loading Sprites only at the beginning
    private Sprite getUISprite(string sName)
    {
        Sprite rSpr = Resources.Load(sName) as Sprite;
        if (rSpr == null)
        {
            Debug.Log("No Sprite loaded");
        }
        return rSpr;
    }

    // It feels wrong to write this..
    public Sprite getAmmoSpriteByID(int ammoID)
    {
        Sprite rSprite = new Sprite();
        AmmoDesc tmp;
        if (ammoByID.TryGetValue(ammoID, out tmp))
        {
            rSprite = tmp.sprite;
        }
        else
        {
            Debug.Log("getAmmoSpriteByID failed for " + ammoID);
        }
        return rSprite;
    }
}