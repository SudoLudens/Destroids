using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float hBounds;
    private float vBounds;

    private float boundOffset = 0.5f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        hBounds = (mainCamera.orthographicSize * mainCamera.aspect) + boundOffset;
        vBounds = mainCamera.orthographicSize + boundOffset;

        if (transform.position.x > hBounds)
        {
            transform.position = new Vector2(-hBounds, transform.position.y);
        }
        if (transform.position.x < -hBounds)
        {
            transform.position = new Vector2(hBounds, transform.position.y);
        }

        if (transform.position.y > vBounds)
        {
            transform.position = new Vector2(transform.position.x, -vBounds);
        }
        if (transform.position.y < -vBounds)
        {
            transform.position = new Vector2(transform.position.x, vBounds);
        }
    }
}
