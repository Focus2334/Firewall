using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public Vector2 GetMovementInput()
    {
        var result = new Vector3();
        var horizontal = 0;
        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
        }
        var vertical = 0;
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
        }
        result.x = horizontal;
        result.y = vertical;
        return result;
    }

    public bool GetFireInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            return true;
        }
        return false;
    }

    public Vector2 GetMousePosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
