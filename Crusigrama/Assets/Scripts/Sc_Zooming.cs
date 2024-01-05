using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Zooming : MonoBehaviour
{
    [SerializeField] private float zoomSpeed;

    private void Update()
    {
        VerticalZooming();
    }

    private void VerticalZooming()
    {
        Vector3 initialPosition = new Vector3();
        // bool canMove = false;

        if (Input.GetMouseButtonDown(0))
        {
            initialPosition = mCamRef.ScreenToViewportPoint(Input.mousePosition);
            Debug.Log(initialPosition.y);

        }

        if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = mCamRef.ScreenToViewportPoint(Input.mousePosition);
            Debug.Log("newPosition" + newPosition.y);

            if (newPosition.y < initialPosition.y)
            {
                Zoom((zoomSpeed * Time.deltaTime) * -1f);
            }
            if (newPosition.y > initialPosition.y)
            {
                Zoom(zoomSpeed * Time.deltaTime);
            }

            intialPosition = newPosition;
        }
    }

    private void Zoom(float inZoomSpeed)
    {
        transform.Translate(mCamRef.transform.position.z * inZoomSpeed * transform.forward);
    }
}
