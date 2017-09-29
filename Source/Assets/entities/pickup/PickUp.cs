using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    private float maxSpeed = 12;
    private float minSpeed = 10;

    private float speed;
    private int powerupCount = 1;

    private Rigidbody body;
    private SpriteRenderer spriteRenderer;
    private Vector3 position;

    public Sprite spriteTicket;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        setRandomSprite();

        body = GetComponent<Rigidbody>();

        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    private void setRandomSprite()
    {
        int random = UnityEngine.Random.Range(1, powerupCount + 1);

        if (random == 1)
        {
            spriteRenderer.sprite = spriteTicket;
        }
        else
        {
            spriteRenderer.sprite = spriteTicket;
        }
    }

    void FixedUpdate()
    {
        if (!Player.gameOver)
        {
            Vector3 movement = new Vector3(0.0f, -speed * PowerUpSpawn.timerMultiplier * Player.timeMultiplier, 0.0f);

            body.velocity = movement;
        }
    }
}
