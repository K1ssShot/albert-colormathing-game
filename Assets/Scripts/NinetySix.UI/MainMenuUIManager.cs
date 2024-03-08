using System;
using System.Collections;
using System.Collections.Generic;
using NinetySix.DATA;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScoretext;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private ScoreSO _scoreSO;
    public GameObject ScoreBoard;
    
    private void Start()
    {
        // starting the scorecounter upon starting game
        ScoreCounter();
    }

    public void ScoreCounter()
    {
        //for scorecounter in main menu
        _currentScoretext.text = _scoreSO.CurrentScore.ToString();
        _scoreSO.AddPoints(0);
        _highScoreText.text = _scoreSO.HighScore.ToString();
        
    }

    public void Play(string levelName)
    {
        // loads the scene and start the new game scene 
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1;

    }

    public void HighScore()
    {
        //viewing the gameobject score menu
        ScoreBoard.SetActive(true);
    }

    public void QuitGame()
    {
        //for application quits 
        Application.Quit();
    }

    public void ScoreBackButton()
    {
        // for hiding the highscore gameobject
        ScoreBoard.SetActive(false);
    }
    
    
}
