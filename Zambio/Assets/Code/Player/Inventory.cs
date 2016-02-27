using UnityEngine;
using System.Collections;
using System;

public class Inventory : MonoBehaviour
{
    public BossBar myBossBar;
    public Ammo ammoContents { get; set; }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

}
[Serializable]
public class Ammo
{

    public enum ammoTypes {  GREEN, RED, BLUE, BULLET, REDBULLET }
    public int greenShells { get; private set; }
    public int redShells { get; private set; }
    public int blueShells { get; private set; }
    public int bulletBill { get; private set; }
    public int redBulletBill { get; private set; }

    Ammo()
    {
        greenShells = redShells = blueShells = 0;
        bulletBill = redBulletBill = 0;
    }

    // For System Wide Use
    // Ammo myAmmo = inventory.ammoContents;
    // int numGreenShells = myAmmo.greenShells;
    // setAmmo( ammoTypes.GREEN, --numGreenShells);

    public void setAmmo( ammoTypes type, int num)
    {
        switch ( type)
        {
            case ammoTypes.GREEN:
                greenShells = num; break;
            case ammoTypes.RED:
                redShells = num; break;
            case ammoTypes.BLUE:
                blueShells = num; break;
            case ammoTypes.BULLET:
                bulletBill = num; break;
            case ammoTypes.REDBULLET:
                redBulletBill = num; break;
            default: break;

        }
    }

}

// How Ammo should work
// Shooting?
//   Ammo plrAmmo;
//   plrAmmo = playerController.ammoContents;
//   // Green shells are loaded
//   if ( isFiring ) {
//      FIRE!!!();
//      plrAmmo.greenShells -= 1;
//      playerController.ammoContents = plrAmmo;
//   }
// 

