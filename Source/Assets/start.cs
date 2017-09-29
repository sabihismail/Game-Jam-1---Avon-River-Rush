using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {
    public Sprite map1;
    public Sprite map2;
    public Sprite map3;
    public Sprite map4;

    private void Start()
    {
        int num = endGameVariables.starCount;

        SpriteRenderer spriteRenderer = GameObject.Find("infosheet").GetComponent<SpriteRenderer>();

        if (num == 0)
        {
            spriteRenderer.sprite = map1;
        }
        else if (num == 1)
        {
            spriteRenderer.sprite = map2;
        }
        else if (num == 2)
        {
            spriteRenderer.sprite = map3;
        }
        else
        {
            spriteRenderer.sprite = map4;
        }
    } 
}
