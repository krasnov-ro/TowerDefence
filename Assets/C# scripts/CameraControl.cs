using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public bool cameraDragging = true;

    public float outerLeft = -10f;
    public float outerRight = 10f;

    private void Start()
    {
    
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float left = Screen.width * 0.2f;
        float right = Screen.width - (Screen.width * 0.2f);

        float up = Screen.height * 0.2f;
        float down = Screen.height - (Screen.height * 0.2f);

        //if (mousePosition.x < left)
        //{
        //    cameraDragging = true;
        //}
        //else if (mousePosition.x > right)
        //{
        //    cameraDragging = true;
        //}

        if (mousePosition.y < up)
        {
            cameraDragging = true;
        }
        else if (mousePosition.y > down)
        {
            cameraDragging = true;
        }

        if (cameraDragging)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

            transform.Translate(move, Space.World);
        }
    }
}
