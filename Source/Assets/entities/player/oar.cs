using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oar : MonoBehaviour {
    public Sprite oar2;
    public Sprite oar3;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update () {
        transform.position = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, GameObject.Find("Player").transform.position.z -0.01f);

        float num = -GameObject.Find("Player").GetComponent<Rigidbody>().velocity.x * 0.01f;

        if (num > 45)
            num = 45;
        else if (num < -45)
            num = -45;

        GetComponent<Transform>().rotation = new Quaternion (GetComponent<Transform>().rotation.x, GetComponent<Transform>().rotation.y, num, GetComponent<Transform>().rotation.w);

        if (Player.level2 && !Player.level3)
        {
            spriteRenderer.sprite = oar2;
        }
        else if (Player.level2 && Player.level3)
        {
            spriteRenderer.sprite = oar3;
        }
    }
}
