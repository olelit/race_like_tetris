using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerateScript : MonoBehaviour
{
    private const string CENTER_TAG = "center";

    private float Height;
    private Vector3 Center;
    private bool IsCrossCenter = false;
    private GameObject Player;
    GameObject RoadPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Center = GetCenterObj().transform.TransformPoint(Vector3.zero);
        Height = 17;
        RoadPrefab = GameObject.FindGameObjectWithTag("road_generate");
    }

    // Update is called once per frame
    void Update()
    {
        CreateNextElement();
    }

    void CreateNextElement()
    {
        if (Player != null && Player.transform.position.y > Center.y-1 && !IsCrossCenter)
        {
            IsCrossCenter = true;
            GameObject[] Roads = GameObject.FindGameObjectsWithTag("road");
            Vector3 nextPos = Roads[Roads.Length - 1].transform.position + transform.up * Height;
            GameObject roadEl = Instantiate(RoadPrefab, nextPos, Roads[0].transform.rotation);
            roadEl.tag = "road";

            GameObject[] roads = GameObject.FindGameObjectsWithTag("road");
            if(roads.Length > 3)
            {
                Destroy(roads[0]);
            }
        }
    }

    GameObject GetCenterObj(string childTag = CENTER_TAG)
    {
        return transform.GetChild(0).gameObject;
    }
}
