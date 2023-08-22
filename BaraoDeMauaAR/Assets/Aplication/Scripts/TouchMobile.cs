using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMobile : MonoBehaviour
{
    public Transform target;  // O objeto que será girado e zoomed
    public float rotateSpeed = 2.0f;  // Velocidade de rotação
    public float zoomSpeed = 0.5f;     // Velocidade de zoom
    public float minZoomDistance = 2.0f;  // Distância mínima de zoom
    public float maxZoomDistance = 10.0f; // Distância máxima de zoom

    private Vector2 prevTouchPos;
    private bool isTouching = false;
    void Update()
    {
        RotateObjects();
        ZoomObject();
    }

    private void RotateObjects()
    {
        // Detecta toques na tela
        if (Input.touchCount == 1)
        {
            // Rotação horizontal e vertical
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = Input.GetTouch(0).deltaPosition;
                float rotationX = -touchDelta.x * rotateSpeed * Time.deltaTime;
                float rotationY = touchDelta.y * rotateSpeed * Time.deltaTime;
                target.Rotate(Vector3.up, rotationX, Space.World);
                target.Rotate(Vector3.right, rotationY, Space.Self);
            }
        }
    }

    private void ZoomObject()
    {
        // Detecção de pinch para zoom
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
                Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

                float prevMagnitude = (touch1PrevPos - touch2PrevPos).magnitude;
                float currentMagnitude = (touch1.position - touch2.position).magnitude;

                float zoomAmount = (prevMagnitude - currentMagnitude) * zoomSpeed * Time.deltaTime;
                float newDistance = Vector3.Distance(target.position, Camera.main.transform.position) + zoomAmount;
                newDistance = Mathf.Clamp(newDistance, minZoomDistance, maxZoomDistance);

                Vector3 zoomDirection = (target.position - Camera.main.transform.position).normalized;
                target.position = Camera.main.transform.position + zoomDirection * newDistance;
            }
        }
    }

}
