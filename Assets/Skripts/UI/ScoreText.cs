using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    [SerializeField]
    private ScoreCounter _scoreCounter;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _bestScore;

    private void OnEnable() {
        _scoreCounter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable() {
        _scoreCounter.ScoreChanged -= OnScoreChanged;
    }

    private void Start() {
        _bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    private void OnScoreChanged(int score) {
        _scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt("BestScore")) {
            PlayerPrefs.SetInt("BestScore", score);
            _bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        }
    }
}
