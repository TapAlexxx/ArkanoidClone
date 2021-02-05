using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    [SerializeField]
    private LevelSpawner _levelSpawner;
    [SerializeField]
    private Player _player;
    [SerializeField]
    private ScoreCounter _scoreCounter;
    [SerializeField]
    private BallSpawner _ballSpawner;


    private void OnEnable() {
        _player.Dead += OnPlayerDead;
    }

    private void OnDisable() {
        _player.Dead -= OnPlayerDead;
    }

    private void Start() {
        _ballSpawner.SpawnBall();
        RestartGame();
    }

    public void OnPlayerDead() {
        RestartGame();
    }

    public void RestartGame() {
        _player.Revive();
        _scoreCounter.ResetScore();
        _levelSpawner.ResetLevel();
    }
}
