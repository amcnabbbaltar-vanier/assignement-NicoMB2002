using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
    }

}
