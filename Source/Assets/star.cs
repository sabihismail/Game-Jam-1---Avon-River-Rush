using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour {
    public Sprite star1;
    public Sprite star2;
    public Sprite star3;

    private void Start()
    {
        int num = endGameVariables.starCount;

        SpriteRenderer spriteRenderer = GameObject.Find("infosheet").GetComponent<SpriteRenderer>();

        if (num <= 1)
        {
            spriteRenderer.sprite = star1;
        }
        else if (num == 2)
        {
            spriteRenderer.sprite = star2;
        }
        else
        {
            spriteRenderer.sprite = star3;
        }

        StartCoroutine(end());
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
    }
}
