using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthPanel : MonoBehaviour {

    public RectTransform coolDownBar;
    public float coolDownBase;
    public Image[] hearts;
    public int health;
    public Image[] ammo;

    public int bullet;  
    private float coolDownCur;

	void Start () {
        coolDownCur = coolDownBase;
        changeAmmo(1);
        coolDownCur = 0.5f;
        bullet = 1;
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            coolDown();
        }
        //if (Input.GetKeyDown("c"))
        //{
        //    setHearts();
        //}
        //if (Input.GetKeyDown("y"))
        //{
        //    health++;
        //    setHearts();
        //}
        //if (Input.GetKeyDown("t"))
        //{
        //    health--;
        //    setHearts();
        //}
        //if (Input.GetKeyDown("1"))
        //{
        //    changeAmmo(1);
        //}
        //if (Input.GetKeyDown("2"))
        //{
        //    changeAmmo(2);
        //}
        //if (Input.GetKeyDown("3"))
        //{
        //    changeAmmo(3);
        //}
        //if (Input.GetKeyDown("4"))
        //{
        //    changeAmmo(4);
        //}
        //if (Input.GetKeyDown("5"))
        //{
        //    changeAmmo(5);
        //}
        //if (Input.GetKeyDown("q"))
        //{
        //    changeAmmo(--bullet);
        //}
        //if (Input.GetKeyDown("e"))
        //{
        //    changeAmmo(++bullet);
        //}
    }

    public void coolDown ()
    {

        if (coolDownCur == coolDownBase)
        {
            coolDownCur = 0f;
            coolDownBar.localScale = new Vector3(0, 0, 1);
            InvokeRepeating("coolDownScaler", 0, 0.01f);
        }

    }

    private void coolDownScaler () //Visual Aid
    {
        if (coolDownCur < coolDownBase)
        {
            coolDownCur++;
            coolDownBar.localScale = new Vector3((float) coolDownCur / coolDownBase, (float) coolDownCur / coolDownBase, 1);
        }
        else
        {
            CancelInvoke("coolDownScaler");
        }
    }

    public void setHearts ()
    {
        if(health < 0)
        {
            health = 0;
        }
        if(health > 10)
        {
            health = 10;
        }

        if (health == 0)
        {
            hearts[0].color = Color.gray;
            hearts[1].color = Color.gray;
            hearts[2].color = Color.gray;
            hearts[3].color = Color.gray;
            hearts[4].color = Color.gray;
        }
        else if(health == 1)
        {
            hearts[0].color = Color.yellow;
            hearts[1].color = Color.gray;
            hearts[2].color = Color.gray;
            hearts[3].color = Color.gray;
            hearts[4].color = Color.gray;
        }
        else if (health == 2)
        {
            hearts[0].color = Color.red;
            hearts[1].color = Color.gray;
            hearts[2].color = Color.gray;
            hearts[3].color = Color.gray;
            hearts[4].color = Color.gray;
        }
        else if (health == 3)
        {
            hearts[0].color = Color.red;
            hearts[1].color = Color.yellow;
            hearts[2].color = Color.gray;
            hearts[3].color = Color.gray;
            hearts[4].color = Color.gray;
        }
        else if (health == 4)
        {
            hearts[0].color = Color.red;
            hearts[1].color = Color.red;
            hearts[2].color = Color.gray;
            hearts[3].color = Color.gray;
            hearts[4].color = Color.gray;
        }
        else if (health == 5)
        {
            hearts[0].color = Color.red;
            hearts[1].color = Color.red;
            hearts[2].color = Color.yellow;
            hearts[3].color = Color.gray;
            hearts[4].color = Color.gray;
        }
        else if (health == 6)
        {
            hearts[0].color = Color.red;
            hearts[1].color = Color.red;
            hearts[2].color = Color.red;
            hearts[3].color = Color.gray;
            hearts[4].color = Color.gray;
        }
        else if (health == 7)
        {
            hearts[0].color = Color.red;
            hearts[1].color = Color.red;
            hearts[2].color = Color.red;
            hearts[3].color = Color.yellow;
            hearts[4].color = Color.gray;
        }
        else if (health == 8)
        {
            hearts[0].color = Color.red;
            hearts[1].color = Color.red;
            hearts[2].color = Color.red;
            hearts[3].color = Color.red;
            hearts[4].color = Color.gray;
        }
        else if (health == 9)
        {
            hearts[0].color = Color.red;
            hearts[1].color = Color.red;
            hearts[2].color = Color.red;
            hearts[3].color = Color.red;
            hearts[4].color = Color.yellow;
        }
        else if (health == 10)
        {
            hearts[0].color = Color.red;
            hearts[1].color = Color.red;
            hearts[2].color = Color.red;
            hearts[3].color = Color.red;
            hearts[4].color = Color.red;
        }

    }

    public void changeAmmo (int ammoType)
    {
        if(!IsInvoking("coolDownScaler")) //Remove To Have A Blast
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

            //if (bullet == 1)
            //{
            //    ammo[0].color = Color.magenta;
            //    ammo[1].color = Color.green;
            //    ammo[2].color = Color.red;
            //    ammo[3].color = Color.blue;
            //    ammo[4].color = Color.yellow;
            //}
            //else if (bullet == 2)
            //{
            //    ammo[0].color = Color.yellow;
            //    ammo[1].color = Color.magenta;
            //    ammo[2].color = Color.green;
            //    ammo[3].color = Color.red;
            //    ammo[4].color = Color.blue;
            //}
            //else if (bullet == 3)
            //{
            //    ammo[0].color = Color.blue;
            //    ammo[1].color = Color.yellow;
            //    ammo[2].color = Color.magenta;
            //    ammo[3].color = Color.green;
            //    ammo[4].color = Color.red;
            //}
            //else if (bullet == 4)
            //{
            //    ammo[0].color = Color.red;
            //    ammo[1].color = Color.blue;
            //    ammo[2].color = Color.yellow;
            //    ammo[3].color = Color.magenta;
            //    ammo[4].color = Color.green;
            //}
            //else if (bullet == 5)
            //{
            //    ammo[0].color = Color.green;
            //    ammo[1].color = Color.red;
            //    ammo[2].color = Color.blue;
            //    ammo[3].color = Color.yellow;
            //    ammo[4].color = Color.magenta;
            //}
        }

    } 

}
