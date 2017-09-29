using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repelled : MonoBehaviour
{
    private float strengthOfRepulsion = 1600f;

    private void FixedUpdate()
    {
        if (!Player.gameOver)
        {
            if (PowerUpSpawn.volumeOn)
            {
                Vector3 direction = GameObject.Find("Player").transform.position + transform.position;
                GetComponent<Rigidbody>().AddForce(strengthOfRepulsion * direction);
            }
        }
    }
}
