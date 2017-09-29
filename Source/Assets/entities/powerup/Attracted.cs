using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attracted : MonoBehaviour
{
    private float strengthOfAttraction = 1600f;
    
    private void FixedUpdate ()
    {
        if (!Player.gameOver)
        {
            if (PowerUpSpawn.vacuumOn)
            {
                Vector3 direction = GameObject.Find("Player").transform.position - transform.position;
                GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
            }
        }
    }
}