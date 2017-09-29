using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour {
	void Update ()
    {
        if (!Player.gameOver)
        {
            float timer = Player.timeDifference;

            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");

            this.GetComponent<TextMesh>().text = minutes + "m:" + seconds + "s";
        }
	}
}
