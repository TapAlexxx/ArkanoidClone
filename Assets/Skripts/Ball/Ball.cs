using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour {
    [SerializeField]
    private float _additionalForce;

    private Rigidbody2D _rigidbody2D;

    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void AddForce() {
        _rigidbody2D.velocity += new Vector2(
                                Random.Range(0, SetForceMultiplier() * _additionalForce),
                                Random.Range(0, SetForceMultiplier() * _additionalForce)
                                ) * Vector2.up;
    }

    private int SetForceMultiplier() {
        if (_rigidbody2D.velocity.y > 0) {
            return 1;
        }
        else {
            return -1;
        }
    }
}
