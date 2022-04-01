using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalManager : MonoBehaviour
{
    [SerializeField] private Text textResult;
    [SerializeField] private string nameScene;
    private GameController gameManager;
    [SerializeField] private bool finalForever;
    void Start()
    {
        gameManager = FindObjectOfType<GameController>();
        if (gameManager)
        {

            gameManager.CalculateScore(textResult);
            if(finalForever)
            {
                Time.timeScale = 0.000001f;
            }
            StartCoroutine(CorRetart());
            IEnumerator CorRetart()
            {
                yield return new WaitForSeconds(4f);
                SceneManager.LoadScene(nameScene);
            }
        }
        else
        {
            SceneManager.LoadScene(nameScene);
        }
    }
}
