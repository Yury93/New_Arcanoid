using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string nameScene;

    private GameController d;
    [SerializeField] private GameController prefabGameController;
    private void Start()
    {
        d = FindObjectOfType<GameController>();
        if(d== null)
        {
            d = Instantiate(prefabGameController, transform.position, Quaternion.identity);
        }
        d.DontDestr();
        d.EndLevel += Instance_EndLevel;
    }

    private void Instance_EndLevel()
    {
        Debug.Log("6");
        SceneManager.LoadScene(nameScene);
        
    }
}