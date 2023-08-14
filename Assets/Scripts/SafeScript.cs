using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeScript : MonoBehaviour
{
    public GameObject onGame;
    public GameObject onWin;

    private void OnTriggerEnter(Collider other)
    {
        // Oyunu Başarıyla Bitirir
        if (other.gameObject.CompareTag("Player"))
        {
            // Karakterin hareketini durdurur
            Time.timeScale = 0f;
            // Ui elementlerini düzenler
            onGame.SetActive(false);
            onWin.SetActive(true);
        }
    }
}
