using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public static int MAIN_MENU = 0;
    public static int SCORE_LIST = 2;
    public static int START = 1;

    public void Back()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }

    public void Restart()
    {
        SceneManager.LoadScene(ButtonsScript.START);
    }

    public void Menu()
    {
        SceneManager.LoadScene(ButtonsScript.MAIN_MENU);
    }
}
