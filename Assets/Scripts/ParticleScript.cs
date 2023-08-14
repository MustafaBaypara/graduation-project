using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        // Karakterin canını azaltır
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterStats>().health -= 1f;
            other.gameObject.GetComponent<CharacterStats>().healthUpdate();
        }
    }
}
