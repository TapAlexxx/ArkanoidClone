using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour {
    [SerializeField]
    private LevelSpawner _levelSpawner;

    private int _currentScore;

    public event UnityAction<int> ScoreChanged;

    private void OnEnable() {
        _levelSpawner.ScoreIncreased += OnScoreIncreased;
    }

    private void OnDisable() {
        _levelSpawner.ScoreIncreased -= OnScoreIncreased;
    }

    private void Start() {
        ResetScore();
    }

    private void OnScoreIncreased(int points) {
        _currentScore += points;
        ScoreChanged?.Invoke(_currentScore);
    }

    public void ResetScore() {
        _currentScore = 0;
        ScoreChanged?.Invoke(_currentScore);
    }
}
