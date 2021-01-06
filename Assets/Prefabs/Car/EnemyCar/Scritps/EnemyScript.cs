using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private float WayMult;
    [SerializeField]
    GameObject Effect;
    void Start()
    {
        WayMult = transform.position.x * 2;

        if (Random.Range(0, 2) == 0)
            transform.position += transform.right * -WayMult;
    }

    public void Die()
    {
        Instantiate(Effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
