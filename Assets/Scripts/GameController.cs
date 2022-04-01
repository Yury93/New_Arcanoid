using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : SingletonBase<GameController>
{
   
    [SerializeField] private BrickList brickList;
    [SerializeField] private BrickList brickListAi;
    public static int scorePlayer;
    public static int scoreAI;
    public  Text textResultPlayer;
    public  Text textResultAI;
    public Text BoundaryText;
    [SerializeField] private bool level1;
    public event Action EndLevel;
    private SceneController sceneController;
    private void Awake()
    {
        brickList = GameObject.Find("BrickList").GetComponent<BrickList>();
        brickListAi = GameObject.Find("BrickList (1)").GetComponent<BrickList>();
    }
    private void Start()
    {
        StartLevel();
    }

    private void ResultGame()
    {
        Debug.Log("3");
        sceneController = FindObjectOfType<SceneController>();
        print(sceneController);
        if (!textResultAI)
        {
            textResultAI = GameObject.Find("TextAI").GetComponent<Text>();
            textResultPlayer = GameObject.Find("TextPlayer").GetComponent<Text>();
            BoundaryText = GameObject.Find("BoundaryText").GetComponent<Text>();
        }
        textResultAI.enabled = true;
        textResultPlayer.enabled = true;
        BoundaryText.enabled = true;

        textResultPlayer.text = scorePlayer.ToString();
        textResultAI.text = scoreAI.ToString();

        brickList = GameObject.Find("BrickList").GetComponent<BrickList>();
        brickListAi = GameObject.Find("BrickList (1)").GetComponent<BrickList>();
       
        if(brickList.Bricks.Count < brickListAi.Bricks.Count)
        {
            Debug.Log("4");
            textResultPlayer.text = scorePlayer.ToString();
            textResultAI.text = scoreAI.ToString();
            StartCoroutine(CorTextMask());
            scorePlayer += 1;
            
            //BrickList.OnResult -= ResultGame;
            return;
        }
        else if(brickList.Bricks.Count > brickListAi.Bricks.Count)
        {
            Debug.Log("4.5");
            textResultPlayer.text = scorePlayer.ToString();
            textResultAI.text = scoreAI.ToString();
            StartCoroutine(CorTextMask());
            scoreAI += 1;
            
            //BrickList.OnResult -= ResultGame;
            return;
        }
        else
        {
           
        }
       
        
    }
    IEnumerator CorTextMask()
    {
        Debug.Log("5");
        yield return new WaitForSeconds(0f);
        
        //textResultAI = GameObject.Find("TextAI").GetComponent<Text>();
        //textResultPlayer = GameObject.Find("TextPlayer").GetComponent<Text>();
        //BoundaryText = GameObject.Find("BoundaryText").GetComponent<Text>();
        textResultPlayer.text = scorePlayer.ToString();
        textResultAI.text = scoreAI.ToString();

        yield return new WaitForSeconds(1f);
        textResultAI.enabled = false;
        textResultPlayer.enabled = false;
        BoundaryText.enabled = false;
        yield return new WaitForSeconds(0.5f);
        EndLevel.Invoke();

    }
    IEnumerator CorTextMaskStart()
    {
        yield return new WaitForSeconds(0.1f);
        textResultPlayer.text = scorePlayer.ToString();
        textResultAI.text = scoreAI.ToString();
        yield return new WaitForSeconds(1f);
        textResultAI.enabled = false;
        textResultPlayer.enabled = false;
        BoundaryText.enabled = false;
    }
    public void CalculateScore(Text result)
    {
        if(scoreAI > scorePlayer)
        {
            result.text = "You were defeated...";
        }
        if (scoreAI < scorePlayer)
        {
            result.text = "Congratulations, you win!!!";
        }
        if (scoreAI == scorePlayer)
        {
            result.text = "Draw...";
        }
    }
    public void StartLevel()
    {
        BrickList.OnResult += ResultGame;

        textResultPlayer.text = scorePlayer.ToString();
        textResultAI.text = scoreAI.ToString();

        if (level1)
        {
            textResultPlayer.text = 0.ToString();
            textResultAI.text = 0.ToString();
            scorePlayer = 0;
            scoreAI = 0;
            level1 = false;
        }
        textResultAI.enabled = true;
        textResultPlayer.enabled = true;
        BoundaryText.enabled = true;
        textResultPlayer.text = scorePlayer.ToString();
        textResultAI.text = scoreAI.ToString();

        StartCoroutine(CorTextMaskStart());
    }
}
