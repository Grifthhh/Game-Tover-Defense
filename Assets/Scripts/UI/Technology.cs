using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Technology : MonoBehaviour
{
    public Bullet bullet;
    public Button button1;

    public void Saldiri10()
    {
        if (Gold.gold >= 100)
        {
            Gold.gold -= 100;
            bullet.damage += bullet.damage * .1f;
            button1.interactable = false;
        }
    }
}
