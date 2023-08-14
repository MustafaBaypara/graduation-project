using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin Transform bileşeni
    public Vector3 offset = new Vector3(0f, 7f, -10f); // Kameranın karaktere olan konumu
    public float smoothSpeed = 0.05f; // Kamera gecikme hızı

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target != null)
        {
            // Hedefin konumuyla offset'i toplayarak kameranın hedefin arkasında kalmasını sağlar
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
