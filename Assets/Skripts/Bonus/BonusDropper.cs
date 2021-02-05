using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDropper : MonoBehaviour {
    [SerializeField]
    private Bonus[] _bonuses;
    [SerializeField]
    private float _dropChance;
    [SerializeField]
    private LevelSpawner _levelSpawner;

    private float _normalizedDropChance;


    private void OnEnable() {
        _levelSpawner.TriedDropBonus += OnTriedDropBonus;
    }

    private void OnDisable() {
        _levelSpawner.TriedDropBonus -= OnTriedDropBonus;
    }

    private void Start() {
        _normalizedDropChance = _dropChance / 100;
    }

    private void OnTriedDropBonus(Transform brickTransform) {
        float chance = Random.Range(0f, 1.0f);
        if (chance < _normalizedDropChance) {
            DropBonus(brickTransform);
        }
    }

    private void DropBonus(Transform brickTransform) {
        int randomBonusNumber = Random.Range(0, _bonuses.Length);
        Instantiate(_bonuses[randomBonusNumber], brickTransform.position, Quaternion.identity);
    }
}
