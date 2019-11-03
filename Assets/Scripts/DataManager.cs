using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    public static DataManager dataManager;
    public float score;
    public float initialScore;
    private void Awake() //Starttan önce çalışır. Gerekli scriptleri çalıştırır.
    {
        if (DataManager.dataManager == null)
        {
            DataManager.dataManager = this;
        }
        else
        {
            if (this != DataManager.dataManager)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(DataManager.dataManager.gameObject);
    }
    public void ReloadLevel()
    {
        score = initialScore;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
        UIController.uiController.SetScoreText(initialScore.ToString());
    }
    public void LoadNextLevel()
    {
        initialScore = score;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/gameSave.oki", FileMode.Create);//Application.persistentDataPath=> Her file için oluşturur.

        bf.Serialize(stream, initialScore);
        bf.Serialize(stream, SceneManager.GetActiveScene().buildIndex);

        stream.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameSave.oki"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/gameSave.oki", FileMode.Open);

            initialScore = (float)bf.Deserialize(stream);
            int savedSceneIndex = (int)bf.Deserialize(stream);

            stream.Close();

            SceneManager.sceneLoaded += PostSceneLoadOperation; //sceneLoaded delegate'ini kullandık.
            SceneManager.LoadScene(savedSceneIndex);

        }
    }
    private void PostSceneLoadOperation(Scene scene, LoadSceneMode loadSceneMode)
    {
        score = initialScore;
        UIController.uiController.SetScoreText(initialScore.ToString());        
        SceneManager.sceneLoaded -= PostSceneLoadOperation;
    }
}
