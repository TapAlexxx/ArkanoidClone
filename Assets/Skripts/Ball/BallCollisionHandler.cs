using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Ball), typeof(AudioSource))]
public class BallCollisionHandler : MonoBehaviour {
    private Ball _ball;
    private AudioSource _audioSource;

    private void Start() {
        _ball = GetComponent<Ball>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent(out Brick brick)) {
            brick.GetComponent<BrickEffector>().AnimateHit();
            brick.ApplyDamage();
        }
        PlayHitSound();
        _ball.AddForce();
    }

    private void PlayHitSound() {
        _audioSource.Play();
    }
}
