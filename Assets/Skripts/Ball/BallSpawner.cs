using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    private const int START_COUNT = 1;

    [SerializeField]
    private Ball _template;
    [SerializeField]
    private Transform _startPoint;
    [SerializeField]
    private float _startForce;
    [SerializeField]
    private BallDieZone _dieZone;
    [SerializeField]
    private Player _player;

    private Vector2 _startVelocity;
    private List<Ball> _spawnedBalls = new List<Ball>();


    private void OnEnable() {
        _dieZone.BallDestroyed += OnBallDestroyed;
    }

    private void OnDisable() {
        _dieZone.BallDestroyed -= OnBallDestroyed;
    }

    private void OnBallDestroyed(Ball ball) {
        if (_spawnedBalls.Count == 1) {
            _player.ApplyDamage();
            _spawnedBalls.Remove(ball);
            Destroy(ball.gameObject);
            if (!_player.IsDead) {
                SpawnBall();
            }
        }
        else {
            _spawnedBalls.Remove(ball);
            Destroy(ball.gameObject);
        }
    }

    public void SpawnBall(int count =START_COUNT) {
        for (int i = 0; i < count; i++) {
            Ball ball = Instantiate(_template, _startPoint.position, Quaternion.identity);
            _spawnedBalls.Add(ball);
            _startVelocity = new Vector2(-1, 1) * _startForce;
            ball.GetComponent<Rigidbody2D>().velocity = _startVelocity;
        }
    }
}
