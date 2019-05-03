using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDisplay : MonoBehaviour
{
    public GameOverController gameOverController;
    
    void Start()
    {
        GameController.isGamePaused = true;

    }

    public void Begin()
    {
        GameController.isGamePaused = false;
        gameObject.SetActive(false);
    }
}
