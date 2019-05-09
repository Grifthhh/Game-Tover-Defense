using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScienceTech : MonoBehaviour
{
    [Header("Buttons")]
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;

    public void Science1()
    {
        if (Science.science >= 100)
        {
            Science.science -= 100;
            GameController.scienceRate += GameController.scienceRate * 0.1f;
            button1.interactable = false;
        }
    }

    public void Build1()
    {
        if (Science.science >= 100)
        {
            Science.science -= 100;
            GameController.permissionLibrary = 2;
            button2.interactable = false;
        }
    }

    public void Science2()
    {
        if (Science.science >= 300 && !button1.interactable)
        {
            Science.science -= 300;
            GameController.scienceRate += GameController.scienceRate * 0.2f;
            button3.interactable = false;
        }
    }

    public void Build2()
    {
        if (Science.science >= 300 && !button2.interactable)
        {
            Science.science -= 300;
            GameController.permissionLibrary = 4;
            button4.interactable = false;
        }
    }

    public void Science3()
    {
        if (Science.science >= 1000 && !button3.interactable && !button4.interactable)
        {
            Science.science -= 1000;
            GameController.scienceRate += GameController.scienceRate * 0.5f;
            button5.interactable = false;
        }
    }

    public void Build3()
    {
        if (Science.science >= 1000 && !button3.interactable && !button4.interactable)
        {
            Science.science -= 1000;
            GameController.permissionLibrary = 100;
            button6.interactable = false;
        }
    }
}
