using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelathBar : MonoBehaviour {
    [SerializeField]
    private GameObject _container;
    [SerializeField]
    private GameObject _heartTemplate;
    [SerializeField]
    private Player _player;

    private void OnEnable() {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable() {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void Start() {
        RefillContainer(_player.CurrentHealth);
    }

    private void OnHealthChanged(int healtCount) {
        RefillContainer(healtCount);
    }

    private void RefillContainer(int healthCount) {
        foreach (Transform heart in _container.transform) {
            Destroy(heart.gameObject);
        }

        for (int i = 0; i < healthCount; i++) {
            Instantiate(_heartTemplate, _container.transform);
        }
    }
}
