﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
   
    public void StartBtn()
    {
        SceneManager.LoadScene(ButtonsScript.START);
    }      
}
