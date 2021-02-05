using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickEffector : MonoBehaviour {
    [SerializeField]
    private GameObject _hitEffect;

    public void AnimateHit() {
        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3);
    }
}
