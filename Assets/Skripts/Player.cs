using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {
    [SerializeField]
    private int _startHealth;

    private int _currentHealth;
    private bool _isDead;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Dead;

    public int CurrentHealth => _currentHealth;
    public bool IsDead => _isDead;

    private void Start() {
        ResetPlayerStats();
    }

    public void ResetPlayerStats() {
        _currentHealth = _startHealth;
        _isDead = false;
        HealthChanged?.Invoke(_currentHealth);
    }

    public void ApplyDamage() {
        _currentHealth--;
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0) {
            _isDead = true;
            Dead?.Invoke();
        }
    }

    public void Revive() {
        _currentHealth = _startHealth;
        HealthChanged?.Invoke(_currentHealth);
        _isDead = false;
    }
}
