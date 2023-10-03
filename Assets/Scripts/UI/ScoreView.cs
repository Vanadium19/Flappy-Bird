using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] TMP_Text _scoreCount;

    private void OnEnable()
    {
        _bird.ScoreChanged += ChangeScore;   
    }

    private void OnDisable()
    {
        _bird.ScoreChanged -= ChangeScore;
    }

    private void ChangeScore(int score)
    {
        _scoreCount.text = score.ToString();
    }
}
