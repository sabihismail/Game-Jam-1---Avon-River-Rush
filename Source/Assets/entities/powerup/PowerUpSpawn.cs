using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public static bool volumeOn;
    private float volumeTimeLeft;
    private float volumeTimeMax = 5f;
    public static float volumeTimeStart;

    public static bool vacuumOn;
    private float vacuumTimeLeft;
    private float vacuumTimeMax = 10f;
    public static float vacuumTimeStart;

    public static float timerMultiplier = 1;
    private float timerTimeLeft;
    private float timerTimeMax = 7f;
    public static float timerTimeStart;

    public static float foodMultiplier = 1;
    private float foodTimeLeft;
    private float foodTimeMax = 7f;
    public static float foodTimeStart;

    private float timeLeft = 10f;

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
                float verticalCameraExtent = Camera.main.orthographicSize;
                float leftHorizontalCameraExtent = GameObject.Find("LeftBoundary").GetComponent<BoxCollider>().bounds.max.x;
                float rightHorizontalCameraExtent = GameObject.Find("RightBoundary").GetComponent<BoxCollider>().bounds.min.x;

                float randomX = Random.Range(leftHorizontalCameraExtent, rightHorizontalCameraExtent);

                Vector3 position = new Vector3(randomX, verticalCameraExtent + 0.5f, 1);

                Instantiate(Resources.Load("Prefabs/PowerUp"), position, Quaternion.identity);

                timeLeft = 10f;
            }

            if (vacuumOn)
            {
                vacuumTimeLeft = Time.time - vacuumTimeStart;

                if (vacuumTimeLeft >= vacuumTimeMax)
                {
                    vacuumTimeLeft = 0;
                    vacuumOn = false;
                    vacuumTimeStart = 0;
                }
            }

            if (volumeOn)
            {
                volumeTimeLeft = Time.time - volumeTimeStart;

                if (volumeTimeLeft >= volumeTimeMax)
                {
                    volumeTimeLeft = 0;
                    volumeOn = false;
                    volumeTimeStart = 0;
                }
            }

            if (timerMultiplier < 1)
            {
                timerTimeLeft = Time.time - timerTimeStart;

                if (timerTimeLeft >= timerTimeMax)
                {
                    timerTimeLeft = 0;
                    timerMultiplier = 1;
                    timerTimeStart = 0;
                }
            }

            if (foodMultiplier > 1)
            {
                foodTimeLeft = Time.time - foodTimeStart;

                if (foodTimeLeft >= foodTimeMax)
                {
                    foodTimeLeft = 0;
                    foodMultiplier = 1;
                    foodTimeStart = 0;
                }
            }
        }
    }

    void decreasingTime()
    {
        timeLeft--;
    }
}
