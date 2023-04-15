using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void LevelOne()
    {

    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
