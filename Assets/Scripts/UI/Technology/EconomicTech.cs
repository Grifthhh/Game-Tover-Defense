using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomicTech : MonoBehaviour
{
    public Button goldBtn;

    [Header("Buttons")]
    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;

    public void GoldBuild()
    {
        if (Science.science >= 100)
        {
            Science.science -= 100;
            GameController.permissionGold = 1;
            button0.interactable = false;
        }
    }

    public void Gold1()
    {
        if (Science.science >= 100 && !button0.interactable)
        {
            Science.science -= 100;
            GameController.goldRate = 0.1f;
            button1.interactable = false;
        }
    }

    public void Build1()
    {
        if (Science.science >= 100 && !button0.interactable)
        {
            Science.science -= 100;
            GameController.permissionGold = 2;
            button2.interactable = false;
        }
    }

    public void Gold2()
    {
        if (Science.science >= 300 && !button1.interactable)
        {
            Science.science -= 300;
            GameController.goldRate = 0.2f;
            button3.interactable = false;
        }
    }

    public void Build2()
    {
        if (Science.science >= 300 && !button2.interactable)
        {
            Science.science -= 300;
            GameController.permissionGold = 4;
            button4.interactable = false;
        }
    }

    public void Gold3()
    {
        if (Science.science >= 1000 && !button0.interactable && !button1.interactable && !button2.interactable && !button3.interactable && !button4.interactable)
        {
            Science.science -= 1000;
            GameController.goldRate = 0.5f;
            button5.interactable = false;
        }
    }

    public void Build3()
    {
        if (Science.science >= 1000 && !button0.interactable && !button1.interactable && !button2.interactable && !button3.interactable && !button4.interactable)
        {
            Science.science -= 1000;
            GameController.permissionGold = 100;
            button6.interactable = false;
        }
    }
}
