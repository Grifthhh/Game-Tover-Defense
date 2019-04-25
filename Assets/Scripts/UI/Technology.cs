using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Technology : MonoBehaviour
{
    public Bullet bullet;
    public Missile missile;
    public Health health;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;

    public void Saldiri1()
    {
        if (Gold.gold >= 100)
        {
            Gold.gold -= 100;
            bullet.damage += bullet.damage * .1f;
            missile.damage += missile.damage * .1f;
            button1.interactable = false;
        }
    }

    public void Zirh1()
    {
        if (Gold.gold >= 100)
        {
            Gold.gold -= 100;
            health.armor += health.armor * .1f;
            button2.interactable = false;
        }
    }

    public void Saldiri2()
    {
        if (Gold.gold >= 300 && !button1.interactable)
        {
            Gold.gold -= 300;
            bullet.damage += bullet.damage * .2f;
            missile.damage += missile.damage * .2f;
            button3.interactable = false;
        }
    }

    public void Zirh2()
    {
        if (Gold.gold >= 300 && !button2.interactable)
        {
            Gold.gold -= 300;
            health.armor += health.armor * .2f;
            button4.interactable = false;
        }
    }

    public void Saldiri3()
    {
        if (Gold.gold >= 1000 && !button1.interactable && !button2.interactable && !button3.interactable && !button4.interactable)
        {
            Gold.gold -= 1000;
            bullet.damage += bullet.damage * .5f;
            missile.damage += missile.damage * .5f;
            button5.interactable = false;
        }
    }

    public void Zirh3()
    {
        if (Gold.gold >= 1000 && !button1.interactable && !button2.interactable && !button3.interactable && !button4.interactable)
        {
            Gold.gold -= 1000;
            health.armor += health.armor * .5f;
            button6.interactable = false;
        }
    }
}
