using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    public float rotationSpeed = 50f; // Engel dönüş hızı

    private void Update()
    {
        // Engel y ekseninde belirtilen hızda döndürmek için
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Engele çarpıldığında
        if (other.gameObject.CompareTag("Player"))
        {
            // Oyuncuyu fırlat
            other.gameObject.GetComponent<CharacterControllerScript>().ThrowPlayer();

        }
    }

}
