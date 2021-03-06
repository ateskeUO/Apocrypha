﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;
    public Vector2 verticalPanLimit;

    public float scrollSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        // WASD moves the camera. In final product so will moving the mouse to the edge of screen but in Unity editor that's a pain in the ass.

        if (Input.GetKey("w") /* || Input.mousePosition.y >= Screen.height - panBorderThickness */)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") /* || Input.mousePosition.y <= panBorderThickness */)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") /* || Input.mousePosition.x <= panBorderThickness */)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") /* || Input.mousePosition.x >= Screen.width - panBorderThickness */)
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        // Zoom in or out with scrollwheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * Time.deltaTime;

        // Clamp possible camera positions based on given variables
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, verticalPanLimit.x, verticalPanLimit.y);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}
