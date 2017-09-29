using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickto4 : MonoBehaviour
{
    public bool isStart;

    void OnMouseUp()
    {
        if (isStart)
        {
            SceneManager.LoadScene(4);
        }
    }
}
