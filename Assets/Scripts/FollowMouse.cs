using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float smoothness = 5f; 

    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 targetPosition = mousePosition;

        Vector2 smoothedPosition = Vector2.Lerp(rectTransform.position, targetPosition, Time.deltaTime * smoothness);
        rectTransform.position = smoothedPosition;
    }
}
