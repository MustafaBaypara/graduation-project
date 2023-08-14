using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterStats : MonoBehaviour
{

    // Projedeki değişken UI elemanlarını tanımlar
    public TMP_Text textMeshPro;
    public int score = 0;
    public Image healthBar;
    public float health = 100f;


    // ui değişkenlerini güncelleme fonksiyonları 
    public void scoreUpdate()
    {
        // Skoru günceller
        textMeshPro.text = score.ToString();
    }

    public void healthUpdate()
    {
        if (health <= 0)
        {
            // Karakterin canı 0'dan küçükse ölür
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        // Can çubuğunu günceller
        healthBar.fillAmount = health / 100f;
    }
}
