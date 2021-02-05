using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Platform : MonoBehaviour {
    private const float START_SCALE_SIZE = 0.5f;

    private Rigidbody2D _rigidbody2D;

    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetSize(float sizeMultiplier) {
        transform.localScale = new Vector3(START_SCALE_SIZE + sizeMultiplier, START_SCALE_SIZE, START_SCALE_SIZE);
    }

    public void SetNormalSize() {
        transform.localScale = new Vector3(START_SCALE_SIZE, START_SCALE_SIZE, START_SCALE_SIZE);
    }
}
