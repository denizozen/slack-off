using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Success : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI scoreText;
    private float score;

    void Update()
    {
        CalculateScore();
    }

    void CalculateScore()
    {
        score = MyCharacterScript.funMeter * 100;
        text.text = score.ToString();
        if (MyCharacterScript.funMeter >= 80)
        {
            scoreText.text = "Awesome job!";
        }
        else if (MyCharacterScript.funMeter < 80 && MyCharacterScript.funMeter >= 50)
        {
            scoreText.text = "Good job, but can be better next time!";
        }
        else
        {
            scoreText.text = "Try harder next time!";
        }
    }
}
