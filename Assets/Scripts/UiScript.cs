using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{ 
    // Projedeki değişken UI elemanlarını tanımlar
    public GameObject onMenu;
    public GameObject onGame;
    public GameObject onWin;
    public Button play;
    public Button quit;
    public Button quit2;
    public Button anamenu;

    void Start()
    {
        // Oyun başlangıcında butonları dinlemeye alır
        Button btnplay = play.GetComponent<Button>();
        btnplay.onClick.AddListener(OnClick);
        Button btnexit = quit.GetComponent<Button>();
        btnexit.onClick.AddListener(doExitGame);
        Button btnana = anamenu.GetComponent<Button>();
        btnana.onClick.AddListener(mainMenu);
        Button btnexit2 = quit2.GetComponent<Button>();
        btnexit2.onClick.AddListener(doExitGame);

    }

    // Oyunu başlatır
    void OnClick()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    // Oyundan çıkar
    void doExitGame()
    {
        Application.Quit();
    }
    // Ana menüye döner
    void mainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
