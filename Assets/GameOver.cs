using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Text foodText;

    void OnEnable() {
        foodText.text = PlayerStats.foodEaten.ToString();
    }
}
