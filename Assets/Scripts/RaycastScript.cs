using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    public Transform startPoint;      // Lazerin başlangıç noktası
    public Transform endPoint;        // Lazerin bitiş noktası
    public int damageAmount = 10;    // Hasar miktarı
    public float maxDistance = 100f; // Raycast maksimum mesafesi
    public float lineThickness = 0.2f; // Lazerin kalınlığı
    public Color lineColor = Color.red; // Lazerin rengi
    private LineRenderer lineRenderer; // Lazer çizici bileşeni
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineThickness;  // Başlangıç kalınlığını ayarla
        lineRenderer.endWidth = lineThickness;    // Bitiş kalınlığını ayarla
        lineRenderer.material.color = lineColor;  // Lazerin rengini ayarla
    }
    private void Update()
    {
        ShootLaser();

    }

    private void ShootLaser()
    {
        // Lazer ışını oluşturma
        Ray ray = new Ray(startPoint.position, (endPoint.position - startPoint.position).normalized);
        RaycastHit hit;

        // Lazer ışınına çarpma kontrolü
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Çarpılan nesnenin etiket kontrolü
            if (hit.collider.CompareTag("Player"))
            {
                GameObject playerHealth = hit.collider.gameObject;
                if (playerHealth != null)
                {
                    //
                    hit.collider.gameObject.GetComponent<CharacterStats>().health -= 1f;
                    hit.collider.gameObject.GetComponent<CharacterStats>().healthUpdate();
                }
            }
        }

        // Lazer ışınını görselleştirme
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);
    }
}

