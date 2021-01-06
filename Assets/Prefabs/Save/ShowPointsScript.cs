using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPointsScript : MonoBehaviour
{
    private SaveManager Manager;

    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("save_manager").GetComponent<SaveManager>();
        GetComponent<Text>().text = Manager.State.Point.ToString();
    }
}
