using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private TextMeshProUGUI scoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<TextMeshProUGUI>();
        scoreLabel.text = "" + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreLabel.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
