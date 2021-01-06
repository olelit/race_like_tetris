using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text ScoreText;
    private SaveManager Manager;

    IEnumerator Start()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("save_manager");
        if (manager != null)
        {
            Manager = manager.GetComponent<SaveManager>();
            ScoreText = GetComponent<Text>();
            while (true)
            {
                yield return new WaitForSeconds(1f);
                AddPoint();
            }
        }
    }

    public void AddPoint()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null && Time.timeScale != 0)
        {
            Manager.State.Point++;
            ScoreText.text = Manager.State.Point.ToString();
        }
    }

}
