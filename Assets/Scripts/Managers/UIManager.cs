using System.Collections.Generic;
using DATA;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;


namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private TextMeshProUGUI _questions;
        [SerializeField] private TextMeshProUGUI _feedbacktext;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _finalScoreText; 
        [SerializeField] private List<Transform> _answerButtons;
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private QuizSO QuizSO;
        [SerializeField] private ScoreSO _scoreSO;
        [SerializeField] private float _startTime = 60f;
        private float _countdown = 0f;
 
  


        private void Start()
        { 

            _questions.text = QuizSO.GetQuestion();
            _countdown = _startTime;
            ShuffleButtons();
        
        }

        private void Update()
        {
            ScoreCount();
            Countdown();
        }
        
        
        private void ScoreCount()
        {
            _scoreText.text = _scoreSO.Score.ToString();
            _finalScoreText.text = _scoreSO.Score.ToString();
            if (_scoreSO.Score  <= 0)
            {
                _scoreSO.Score = 0;
            }
            Debug.Log("Points is Counting");
            
        }

        private void Countdown()
        {
            _timerText.text = _countdown.ToString("0");
            _countdown -= 1 * Time.deltaTime;
            
            if (_countdown <= 0)
            {
               _gameOverScreen.SetActive(true);
                _countdown = 0;
                 Debug.Log("GameOver");
            
            }
        }

        private void ShuffleButtons()
        {

            int randomindex = UnityEngine.Random.Range(0, _answerButtons.Count);
            Transform buttonsSpawner = _answerButtons[randomindex];

        }
        
        public void CHeckAnswers(ColorID SelectedColorID)
        {
            
            if (SelectedColorID == QuizSO.ColorDataID)
            {
                Debug.Log("CorrectAnswer minus points");
                _feedbacktext.text = "Correct";
                _gameManager.ColorSelector();
                _scoreSO.Score++;

            }
            else
            {
                Debug.Log("IncorrectAnswer");
                _feedbacktext.text = "InCorrect";
                _scoreSO.Score--;
                _countdown -= 5f;
            }
        }

        public void Mainmenu(string levelName)
        {
            SceneManager.LoadScene(levelName);
            _gameOverScreen.SetActive(false);

        }
        public void TryAgain(string levelName)
        {
            SceneManager.LoadScene(levelName);
            _gameOverScreen.SetActive(false);
        }

        public void SpawnRed()
        {
       
            CHeckAnswers(ColorID.Red);
       
        }
    
        public void SpawnBlue()
        { 
            CHeckAnswers(ColorID.Blue);
        
        }
        public void SpawnGreen()
        {
            CHeckAnswers(ColorID.Green);
        }  
    
        public void SpawnYellow()
        {
            CHeckAnswers(ColorID.Yellow);
        }
    }
}
