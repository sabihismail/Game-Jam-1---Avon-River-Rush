using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickto2 : MonoBehaviour {
	public bool isStart;
    
	void OnMouseUp() {
		if(isStart)
		{
            endGameVariables.starCount = 50;

			SceneManager.LoadScene (2);
		}
	}
}
