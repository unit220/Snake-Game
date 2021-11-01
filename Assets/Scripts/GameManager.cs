using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameEnded;

    // Start is called before the first frame update
    void Start()
    {
        this.gameEnded = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameEnded) {
            Time.timeScale = 0;
        }
    }

    public void EndGame()
    {
        this.gameEnded = true;
        //this.gameOverUI.SetActive(true); TODO: Add this
    }
}
