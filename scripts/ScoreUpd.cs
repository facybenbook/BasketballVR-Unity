using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpd : MonoBehaviour
{
    public int score = 0;
    public TextMeshPro scoreText;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score += 10;
            scoreText.text = "Score: " + score;
        }
    }
}
