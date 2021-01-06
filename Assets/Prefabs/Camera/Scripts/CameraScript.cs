using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    const string PLAYER_TAG = "Player";

    private GameObject Player;

    [SerializeField]
    public float Distance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag(PLAYER_TAG);

    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            transform.position = new Vector3(
                transform.position.x,
                Player.transform.position.y + Distance,
                transform.position.z
            );
        }

    }
}
