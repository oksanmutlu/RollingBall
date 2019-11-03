using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button newGameButton, loadButton, settingsButton, creditsButton, quitButton,settingsPanelCloseButton;
    public Transform settingsPanel;
    
    private void Start()
    {
        newGameButton.onClick.AddListener(StartNewGame);
        loadButton.onClick.AddListener(LoadSaveGame);
        settingsButton.onClick.AddListener(OpenSettingsPanel);

        quitButton.onClick.AddListener(QuitGame);
    }

 

    private void StartNewGame()
    {
        DataManager.dataManager.score = 0;
        DataManager.dataManager.initialScore = 0;
        if (UIController.uiController!=null)
        {
            UIController.uiController.SetScoreText("0");
        }
        SceneManager.LoadScene(1);        
    }
    private void LoadSaveGame()
    {
        DataManager.dataManager.Load();
    }
    private void OpenSettingsPanel()
    {
        settingsPanel.gameObject.SetActive(true);
        //transform.Find("SettingsPanel").gameObject.SetActive(true); Üst satırdaki kodun referanssız hali.
    }
    private void CloseSettingPanel()
    {
        settingsPanel.gameObject.SetActive(false);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
