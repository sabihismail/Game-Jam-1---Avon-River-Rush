using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawn : MonoBehaviour
{
    private int max = 2;
    private int min = 0;
    private float timeLeft = 1.0f;

    private void Start()
    {
        InvokeRepeating("decreasingTime", 1.0f, 1.0f);
    }

    void Update()
    {
        if (!Player.gameOver)
        {
            if (timeLeft == 0)
            {
                if (Random.Range(min, max) > 0)
                {
                    float verticalCameraExtent = Camera.main.orthographicSize;
                    float leftHorizontalCameraExtent = GameObject.Find("LeftBoundary").GetComponent<BoxCollider>().bounds.max.x;
                    float rightHorizontalCameraExtent = GameObject.Find("RightBoundary").GetComponent<BoxCollider>().bounds.min.x;

                    float randomX = Random.Range(leftHorizontalCameraExtent, rightHorizontalCameraExtent);

                    Vector3 position = new Vector3(randomX, verticalCameraExtent + 0.5f, 1);

                    Instantiate(Resources.Load("Prefabs/PickUp"), position, Quaternion.identity);
                }
            }

            timeLeft = 1.0f;
        }
    }

    void decreasingTime()
    {
        timeLeft--;
    }
}
