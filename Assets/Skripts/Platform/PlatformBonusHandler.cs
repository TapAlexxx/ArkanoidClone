using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformMover), typeof(Platform))]
public class PlatformBonusHandler : MonoBehaviour
{
    private const float SPEED_START_MULTIPLIER = 1;

    [SerializeField]
    private float _speedMultiplier;
    [SerializeField]
    private float _sizeMultiplier;
    [SerializeField]
    private float _speedDuration;
    [SerializeField]
    private float _sizeDuration;
    [SerializeField]
    private int _ballCount;
    [SerializeField]
    private BallSpawner _ballSpawner;

    private PlatformMover _platformMover;
    private Platform _platform;


    private void Start() {
        _platformMover = GetComponent<PlatformMover>();
        _platform = GetComponent<Platform>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent(out Bonus bonus)) {
            switch (bonus.BonusEnchantment) {
                case Bonus.BonusType.positiveSpeed:
                    StartCoroutine(BoostMoveSpeed(true));
                    break;
                case Bonus.BonusType.negativeSpeed:
                    StartCoroutine(BoostMoveSpeed(false));
                    break;
                case Bonus.BonusType.positiveSize:
                    StartCoroutine(ChangeSize(true));
                    break;
                case Bonus.BonusType.negativeSize:
                    StartCoroutine(ChangeSize(false));
                    break;
                case Bonus.BonusType.aditionalBalls:
                    _ballSpawner.SpawnBall(_ballCount);
                    break;
                default:
                    break;
            }
        }
        Destroy(collision.gameObject);
    }

    private IEnumerator BoostMoveSpeed(bool isPositive) {
        if (isPositive) {
            _platformMover.SetSpeedMultiplier(_speedMultiplier);
        }
        else {
            _platformMover.SetSpeedMultiplier(-_speedMultiplier);
        }

        float duration = _speedDuration;
        while (duration > 0) {
            yield return new WaitForSeconds(1);
            duration--;
        }
        _platformMover.SetSpeedMultiplier(SPEED_START_MULTIPLIER);
    }

    private IEnumerator ChangeSize(bool isPositive) {
        if (isPositive) {
            _platform.SetSize(_sizeMultiplier);
        }
        else {
            _platform.SetSize(-_sizeMultiplier);
        }

        float duration = _sizeDuration;
        while (duration > 0) {
            yield return new WaitForSeconds(1);
            duration--;
        }
        _platform.SetNormalSize();
    }
}
