using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour {
    private float scrollSpeed = 0.8f;
    private Vector2 currentOffset;

    void Update ()
    {
        if (!Player.gameOver)
        {
            currentOffset.y -= Time.deltaTime * scrollSpeed * PowerUpSpawn.timerMultiplier;
            GetComponent<Renderer>().material.mainTextureOffset = currentOffset;
        }
    }
}
