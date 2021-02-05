using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformMover : MonoBehaviour {
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigidbody2D;
    private bool _isButtonControl;
    private Vector3 _buttonsAxis;
    private Vector3 _mouseAxis;
    private float _mouseActionFieldOffset = 150;
    private float _speedMultiplier = 1;


    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _buttonsAxis.x = Input.GetAxis("Horizontal");
        _mouseAxis.x = Input.GetAxis("Mouse X");

        if (_buttonsAxis.x != 0) {
            _isButtonControl = true;
        }
        if (_mouseAxis.x != 0) {
            _isButtonControl = false;
        }

        MovePlatform();
    }

    private bool IsMouseOutOfScreen() {
        return (Input.mousePosition.x > _mouseActionFieldOffset &&
                Input.mousePosition.x < Screen.width - _mouseActionFieldOffset &&
                Input.mousePosition.y > 0 &&
                Input.mousePosition.y < Screen.height);
    }

    private void MovePlatform() {
        if (_isButtonControl) {
            _rigidbody2D.velocity = new Vector3(_buttonsAxis.x * (_speed + _speedMultiplier), 0, 0);
        }
        else if (!_isButtonControl && IsMouseOutOfScreen()) {
            _rigidbody2D.velocity = Vector2.zero;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(mousePosition.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, (_speed + _speedMultiplier) * Time.deltaTime);
        }
    }

    public void SetSpeedMultiplier(float multiplier) {
        _speedMultiplier = multiplier;
    }
}
