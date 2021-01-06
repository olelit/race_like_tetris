using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private int Health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int SubHealth()
    {
        Health--;
        if(transform.childCount > 0)
        {
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
        }


        return Health;
    }
}
