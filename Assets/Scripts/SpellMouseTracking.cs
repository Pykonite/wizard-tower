using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class SpellMouseTracking : MonoBehaviour
{
    private Camera _mainCamera;
    public InputAction Left, Right, Up, Down;

    void Start()
    {
        _mainCamera = Camera.main;
        if(Gamepad.all.Count > 0)
        {
            Left.Enable();
            Right.Enable();
            Up.Enable();
            Down.Enable();
        }
    }

    void Update()
    {
        
        if (Gamepad.all.Count !> 0)
        {
            transform.position = GetMouseWorldPosition();
        }
        if (Up.IsPressed())
        {
            transform.position += 10;
        }
    }

    Vector2 GetMouseWorldPosition()
    {
        return _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
    Vector2 ControllerXSense()
    {

    }
}
