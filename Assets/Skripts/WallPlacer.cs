using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WallPlacer : MonoBehaviour {
    private enum WallType {
        left,
        right,
        top
    };

    [SerializeField]
    private WallType _type;


    private void Update() {
        PlaceWall(_type);
    }

    private void PlaceWall(WallType type) {
        switch (type) {
            case WallType.left:
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10));
                ResizeWall(_type);
                break;
            case WallType.right:
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 10));
                ResizeWall(_type);
                break;
            case WallType.top:
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 10));
                ResizeWall(_type);
                break;
            default:
                break;
        }
    }

    private void ResizeWall(WallType type) {
        switch (type) {
            case WallType.left:
                transform.localScale = new Vector3(1, 20, 1);
                break;
            case WallType.right:
                transform.localScale = new Vector3(1, 20, 1);
                break;
            case WallType.top:
                transform.localScale = new Vector3(40, 1, 1);
                break;
            default:
                break;
        }
    }
}
