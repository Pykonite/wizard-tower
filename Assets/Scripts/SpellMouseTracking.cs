using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMouseTracking : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.position = GetMouseWorldPosition();
    }

    Vector2 GetMouseWorldPosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
