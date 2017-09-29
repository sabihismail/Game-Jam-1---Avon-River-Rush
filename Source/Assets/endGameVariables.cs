using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameVariables : MonoBehaviour {
    public static int starCount;

    void Awake ()
    {
        DontDestroyOnLoad(this);
    }   
}
