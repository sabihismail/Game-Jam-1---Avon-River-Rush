using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static float timeDifference;
    public static float timeMultiplier = 1;

    public static bool gameOver;

    public static bool level2;
    public static bool level3;

    public static int totalScore;
    private int totalScoreLevel2 = 60;
    private int totalScoreLevel3 = 90;
    private int ticketCount;

    private int lives = 3;
    private float speed = 8;
    private float timeStart = 0;

    private Rigidbody playerBody;
    
    private AudioSource clickButton;
    public AudioSource[] audioList;

    public Sprite boat2;
    public Sprite boat3;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Screen.SetResolution(1280, 720, true, 60);
        audioList = GetComponents<AudioSource>();

        playerBody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        timeStart = Time.time;
        clickButton = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag.Contains("Block"))
        {
            playerBody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            reduceLife();

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "PowerUp")
        {
            PowerUp obj = collision.gameObject.GetComponent<PowerUp>();
            audioList[1].Play();

            if (obj.GetComponent<SpriteRenderer>().sprite == obj.spriteTime)
            {
                PowerUpSpawn.timerTimeStart = Time.time;

                PowerUpSpawn.timerMultiplier = 0.5f;
            }
            else if (obj.GetComponent<SpriteRenderer>().sprite == obj.spriteVacuum)
            {
                PowerUpSpawn.vacuumTimeStart = Time.time;

                PowerUpSpawn.vacuumOn = true;
            }
            else if (obj.GetComponent<SpriteRenderer>().sprite == obj.spriteVolume)
            {
                PowerUpSpawn.volumeTimeStart = Time.time;

                PowerUpSpawn.volumeOn = true;
            }
            else if (obj.GetComponent<SpriteRenderer>().sprite == obj.spriteFood)
            {
                PowerUpSpawn.foodTimeStart = Time.time;

                PowerUpSpawn.foodMultiplier = 2f;
            }

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "PickUp")
        {
            ticketCount++;

            TextMesh textMesh = GameObject.Find("GUITickets").GetComponent<TextMesh>();
            textMesh.text = ticketCount.ToString();
            audioList[0].Play();

            Destroy(collision.gameObject);
        }
    }

    private void reduceLife()
    {
        lives--;

        TextMesh textMesh = GameObject.Find("GUILives").GetComponent<TextMesh>();
        textMesh.text = lives.ToString();
        audioList[3].Play();

        if (lives == 0)
        {
            GameObject destructionGameObject = Instantiate(Resources.Load("Prefabs/Destruction01")) as GameObject;
            ParticleSystem destruction = destructionGameObject.GetComponent<ParticleSystem>();
            destruction.Play();

            gameOver = true;
            gameOverMethod();
        }
    }

    private void gameOverMethod()
    {
        audioList[2].Play();
        int num = calculateStars();
        
        endGameVariables.starCount = num;

        StartCoroutine(Resume(3));
    }

    private int calculateStars()
    {
        int num = (int)(Mathf.Log(totalScore * 0.7f) - 2);

        if (num > 3)
            return 3;

        return num;
    }

    private IEnumerator Resume(int v)
    {
        yield return new WaitForSeconds(v);

        SceneManager.LoadScene(3);
    }

    void Update()
    {
        timeDifference = Time.time - timeStart;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            clickButton.Play();
        } else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            clickButton.Stop();
        }

        float num = Mathf.Log(Mathf.Log((timeDifference / 2f) * 0.7f));
        if (num < 1 || float.IsNaN(num) || float.IsInfinity(num))
            timeMultiplier = 1;
        else
            timeMultiplier = num;

        totalScore = (int) (timeDifference + ticketCount);

        if (totalScore >= totalScoreLevel2)
        {
            level2 = true;
            spriteRenderer.sprite = boat2;
        }

        if (totalScore >= totalScoreLevel3)
        {
            level3 = true;
            spriteRenderer.sprite = boat3;
        }
    }

    void FixedUpdate()
    {
        if (!gameOver)
        {
            float horizontal = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(horizontal, 0.0f, 0.0f);

            playerBody.velocity = speed * PowerUpSpawn.foodMultiplier * movement * timeMultiplier;
        }
    }

}