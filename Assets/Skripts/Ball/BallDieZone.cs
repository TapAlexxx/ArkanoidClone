using UnityEngine;
using UnityEngine.Events;

public class BallDieZone : MonoBehaviour
{
    public event UnityAction<Ball> BallDestroyed;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent(out Ball ball)) {
            BallDestroyed?.Invoke(ball);
        }
    }
}
