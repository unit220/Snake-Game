using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Snake";
    public void Play () {
        Debug.Log("Play");
        SceneManager.LoadScene(levelToLoad);
    }
}
