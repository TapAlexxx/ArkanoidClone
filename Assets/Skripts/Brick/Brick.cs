using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Brick : MonoBehaviour {
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _scorePoints;
    [SerializeField]
    private Sprite _maxHealthSprite;
    [SerializeField]
    private Sprite _lowHealthSprite;

    private SpriteRenderer _spriteRenderer;

    public int ScorePoints => _scorePoints;

    public event UnityAction<Brick> BrickDestroyed;


    private void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ApplyDamage() {
        _health--;
        if (_health <= 0) {
            DestroyBrick();
        }
        else {
            SetSpriteEqualsToHealth(_health);
        }
    }

    private void SetSpriteEqualsToHealth(int health) {
        if (health <= 2) {
            _spriteRenderer.sprite = _lowHealthSprite;
        }
    }

    private void DestroyBrick() {
        BrickDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
