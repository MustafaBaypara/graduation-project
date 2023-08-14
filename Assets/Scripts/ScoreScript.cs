using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    // Score objesini döndürür
    void Update()
    {
        transform.Rotate(Vector3.forward * 50f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Score objesine karakter çarpıldığını tespit eder
        if (other.gameObject.CompareTag("Player"))
        {
            // Score objesini yok eder
            Destroy(gameObject);
            // Oyuncunun skorunu arttır
            other.gameObject.GetComponent<CharacterStats>().score++;
            // Skoru ekrana yazdır
            other.gameObject.GetComponent<CharacterStats>().scoreUpdate();
        }
    }
}
