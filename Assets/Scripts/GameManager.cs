using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;

    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded) {
            Time.timeScale = 0;
        }
    }

    public void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}
