using UnityEngine;
using UnityEngine.InputSystem;

public class SpellMouseTracking : MonoBehaviour
{
    private Camera _mainCamera;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        transform.position = GetMouseWorldPosition();
    }

    Vector2 GetMouseWorldPosition()
    {
        return _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}
