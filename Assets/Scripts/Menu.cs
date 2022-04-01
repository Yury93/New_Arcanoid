using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string nameScene;
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(nameScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
