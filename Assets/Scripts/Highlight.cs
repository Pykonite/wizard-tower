using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Highlight : MonoBehaviour
{ 
    public int spell, count;
    private Renderer _renderer;
    private Ray2D _cameraRay2D;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        spell = CastSpells.Spell;
        _renderer.material.color = spell == count ? Color.blue : Color.white;
        var ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        var cast = Physics2D.Raycast(ray.origin, ray.direction);
        if
        (
            cast.rigidbody &&
            cast.rigidbody.gameObject == gameObject &&
            Mouse.current.leftButton.wasReleasedThisFrame
        )
        {
            CastSpells.Spell = count;
        }
    }
}
