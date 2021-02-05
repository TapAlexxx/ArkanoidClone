using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class LevelSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject[] _levels;
    [SerializeField]
    private Transform _levelSpawnPoint;
    [SerializeField]
    private BallSpawner _ballSpawner;

    private GameObject _currentLevel;
    private List<Brick> _bricks = new List<Brick>();
    private AudioSource _audioSource;

    public event UnityAction<int> ScoreIncreased;
    public event UnityAction<Transform> TriedDropBonus;


    private void Start() {
        _audioSource = GetComponent<AudioSource>();
        ResetLevel();
    }

    public void ResetLevel() {
        if (_currentLevel != null) {
            Destroy(_currentLevel);
            _bricks.Clear();
        }
        SpawnLevel();
    }

    public void SpawnLevel() {
        _currentLevel = Instantiate(_levels[Random.Range(0, _levels.Length)], _levelSpawnPoint.position, Quaternion.identity);
        Brick[] bricks = _currentLevel.GetComponentsInChildren<Brick>();
        foreach (Brick brick in bricks) {
            _bricks.Add(brick);
            brick.BrickDestroyed += OnBrickDestroyed;
        }
    }

    public void OnBrickDestroyed(Brick brick) {
        ScoreIncreased?.Invoke(brick.ScorePoints);
        TriedDropBonus?.Invoke(brick.transform);

        _bricks.Remove(brick);
        brick.BrickDestroyed -= OnBrickDestroyed;

        PlayBrickDestroySound();

        CheckForEndOfLevel();
    }

    private void CheckForEndOfLevel() {
        if (_bricks.Count <= 0) {
            SpawnLevel();
        }
    }

    private void PlayBrickDestroySound() {
        _audioSource.Play();
    }

}
