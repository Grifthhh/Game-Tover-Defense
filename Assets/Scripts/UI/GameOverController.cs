using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Image img;
    public Text txt;
    public Button btn;
    public Text btnTxt;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameController.isGameOver)
        {
            anim.SetTrigger("gameOver");
            txt.enabled = true;
            btn.enabled = true;
            btn.image.enabled = true;
            btnTxt.enabled = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
