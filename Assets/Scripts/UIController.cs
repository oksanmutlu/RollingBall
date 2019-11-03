using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController uiController; //Singelton uyguladık
    public Text scoreText;
    public Button resumeButton, saveButton, loadButton, mainMenuButton, menuButton;
    public Transform inGameMenuPanel;


    private void Awake()
    {        
        //Singelton
        if (uiController==null)
        {
            uiController = this;
        }
        else
        {
            if (this != uiController)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(uiController.gameObject);

    }
    void Start()
    {
        scoreText.text = DataManager.dataManager.score.ToString();
        saveButton.onClick.AddListener(SaveGame);
        loadButton.onClick.AddListener(LoadGame);
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(QuitToMainMenu);
        menuButton.onClick.AddListener(OpenInGameMenu);
    }

    private void OpenInGameMenu()
    {
        Time.timeScale = 0;
        inGameMenuPanel.gameObject.SetActive(true);
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
        inGameMenuPanel.gameObject.SetActive(false);
    }    
  private void QuitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
       
    }

    public void SetScoreText(string aScoreString)
    {
        scoreText.text ="Score: "+ aScoreString;
    }
    private void SaveGame()
    {
        DataManager.dataManager.Save();
    }
    private void LoadGame()
    {
        DataManager.dataManager.Load();
    }
}
