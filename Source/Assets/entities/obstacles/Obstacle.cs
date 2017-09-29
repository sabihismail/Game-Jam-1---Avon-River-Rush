using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    private float maxSpeed = 11;
    private float minSpeed = 9;

    private float speed;
    private int obstacleCount = 3;

    private Rigidbody body;
    private SpriteRenderer spriteRenderer;
    private Vector3 position;

    public Sprite spriteLog;
    public Sprite spriteRock;

    public Sprite spriteDuck;
    public Sprite spriteMrGoose;
    public Sprite spriteSwan;
    private float index;
    private float amplitude;
    private float omega = 4f;
    [Range(0, 10)]
    private float frequency = 1;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        setRandomSprite();

        body = GetComponent<Rigidbody>();

        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    } 

    private void setRandomSprite()
    {
        int random = UnityEngine.Random.Range(1, obstacleCount + 1);

        if (random == 1)
        {
            spriteRenderer.sprite = spriteLog;
        }
        else if (random == 2)
        {
            spriteRenderer.sprite = spriteRock;
        }
        else if (random == 3)
        {
            spriteRenderer.sprite = spriteDuck;
        }
        else if (random == 4)
        {
            spriteRenderer.sprite = spriteSwan;
        }
        else if (random == 5)
        {
            spriteRenderer.sprite = spriteMrGoose;
        }
        else
        {
            spriteRenderer.sprite = spriteLog;
        }
    }

    void FixedUpdate()
    {
        if (!Player.gameOver)
        {
            Vector3 movement = new Vector3(0.0f, -speed * PowerUpSpawn.timerMultiplier * Player.timeMultiplier, 0.0f);

            if (spriteRenderer.sprite == spriteDuck || spriteRenderer == spriteMrGoose || spriteRenderer == spriteSwan)
            {
                amplitude = GameObject.Find("LeftBoundary").GetComponent<BoxCollider>().bounds.max.x;
                index += Time.deltaTime * frequency;

                float x = amplitude * Mathf.Cos(omega * index);
                movement.x = x * PowerUpSpawn.foodMultiplier * Player.timeMultiplier;
            }

            body.velocity = movement;
        }
    }
}
