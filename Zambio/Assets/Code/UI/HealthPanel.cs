using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HealthPanel : MonoBehaviour
{

    public RectTransform coolDownBar;
    public float coolDownBase;
    public Image[] hearts;
    public Sprite[] heartIcons;
    public int health;
    public Image[] ammo;


    /* Begin Todd Testing Section */
    GameControllerSingleton gc;


    public Sprite[] ammoIcons;

    public int bullet;

    private float coolDownCur;

    void Start()
    {
        coolDownCur = coolDownBase;
        changeAmmo(1);
        coolDownCur = 0.5f;
        bullet = 1;

        gc = GameControllerSingleton.get();

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            coolDown();
        }

        if (Input.GetKeyDown("z"))
        {
            health--;
            setHearts();
        }
        if (Input.GetKeyDown("x"))
        {
            health++;
            setHearts();
        }

    }

    public void coolDown()
    {

        if (coolDownCur == coolDownBase)
        {
            coolDownCur = 0f;
            coolDownBar.localScale = new Vector3(0, 0, 1);
            InvokeRepeating("coolDownScaler", 0, 0.01f);
        }

    }

    private void coolDownScaler() //Visual Aid
    {
        if (coolDownCur < coolDownBase)
        {
            coolDownCur++;
            coolDownBar.localScale = new Vector3((float)coolDownCur / coolDownBase, (float)coolDownCur / coolDownBase, 1);
        }
        else
        {
            CancelInvoke("coolDownScaler");
        }
    }

    public void setHearts()
    {
        if (health < 0)
        {
            health = 0;
        }
        if (health > 20)
        {
            health = 20;
        }

        int fullHeart = health / 4;
        int partHeart = health % 4;

        for (int i = 0; i < 5; i++)
        {
            if (i <= fullHeart - 1)
            {
                hearts[i].sprite = heartIcons[3];
                hearts[i].color = Color.red;
            }
            else if (i == fullHeart && partHeart > 0)
            {
                switch (partHeart)
                {
                    case 1:
                        hearts[i].sprite = heartIcons[0];
                        break;
                    case 2:
                        hearts[i].sprite = heartIcons[1];
                        break;
                    case 3:
                        hearts[i].sprite = heartIcons[2];
                        break;
                    default:
                        break;
                }
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.clear;
            }
        }

    }

    public void changeAmmo(int ammoType)
    {
        //Sprite test = gc.getAmmoSpriteByID(0);
        if (!IsInvoking("coolDownScaler")) //Remove To Have A Blast
        {

            coolDownCur = coolDownBase;
            coolDownBar.localScale = new Vector3((float)coolDownCur / coolDownBase, (float)coolDownCur / coolDownBase, 1);

            bullet = ammoType;

            if (bullet < 1)
            {
                bullet = 5;
            }
            if (bullet > 5)
            {
                bullet = 1;
            }

            switch (bullet)
            {
                case 1:
                    ammo[0].color = Color.magenta;
                    //ammo[0].sprite = gc.getAmmoSpriteByID(0);
                    ammo[1].color = Color.green;
                    ammo[2].color = Color.red;
                    ammo[3].color = Color.blue;
                    ammo[4].color = Color.yellow;
                    break;
                case 2:
                    ammo[0].color = Color.yellow;
                    ammo[1].color = Color.magenta;
                    ammo[2].color = Color.green;
                    ammo[3].color = Color.red;
                    ammo[4].color = Color.blue;
                    break;
                case 3:
                    ammo[0].color = Color.blue;
                    ammo[1].color = Color.yellow;
                    ammo[2].color = Color.magenta;
                    ammo[3].color = Color.green;
                    ammo[4].color = Color.red;
                    break;
                case 4:
                    ammo[0].color = Color.red;
                    ammo[1].color = Color.blue;
                    ammo[2].color = Color.yellow;
                    ammo[3].color = Color.magenta;
                    ammo[4].color = Color.green;
                    break;
                case 5:
                    ammo[0].color = Color.green;
                    ammo[1].color = Color.red;
                    ammo[2].color = Color.blue;
                    ammo[3].color = Color.yellow;
                    ammo[4].color = Color.magenta;
                    break;
                default:
                    break;
            }

        }

    }

}
