using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    private float maxSpeed = 14;
    private float minSpeed = 12;

    private float speed;
    private int powerupCount = 4;

    private Rigidbody body;
    private SpriteRenderer spriteRenderer;
    private Vector3 position;

    public Sprite spriteTime;
    public Sprite spriteVolume;
    public Sprite spriteVacuum;
    public Sprite spriteFood;

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
            spriteRenderer.sprite = spriteTime;
        }
        else if (random == 2)
        {
            spriteRenderer.sprite = spriteVolume;
        }
        else if (random == 3)
        {
            spriteRenderer.sprite = spriteVacuum;
        }
        else if (random == 4)
        {
            spriteRenderer.sprite = spriteFood;
        }
        else
        {
            spriteRenderer.sprite = spriteTime;
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
