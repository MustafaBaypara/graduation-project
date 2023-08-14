using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerScript : MonoBehaviour
{
    public Transform targetPoint;   // Hedef noktanın Transform bileşeni
    public float moveSpeed = 5f;    // Hareket hızı

    private Vector3 startingPosition;    // Başlangıç pozisyonu
    private Vector3 targetPosition;      // Hedef pozisyonu
    private bool movingToTarget = true;  // Hedefe doğru mu hareket ediyor

    private void Start()
    {
        // Başlangıç ve hedef pozisyonlarını alır
        startingPosition = transform.position;
        targetPosition = targetPoint.position;
    }

    private void Update()
    {
        if (movingToTarget)
        {
            // Hedefe doğru hareket et
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Hedefe ulaşıldığında yönü tersine çevir
            if (transform.position == targetPosition)
                movingToTarget = false;
        }
        else
        {
            // Başlangıç pozisyonuna doğru hareket et
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);

            // Başlangıç pozisyonuna ulaşıldığında yönü tersine çevir
            if (transform.position == startingPosition)
                movingToTarget = true;
        }
    }

    void OnTriggerStay(Collider collision)
    {
        // Karakterin canını azalt
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterStats>().health -= 1f;
            collision.gameObject.GetComponent<CharacterStats>().healthUpdate();
        }
    }
}
