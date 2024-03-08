using System;
using NinetySix.DATA;
using GamePlay;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI _questions;
        [SerializeField] private TextMeshProUGUI _feedbacktext;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _finalScoreText;
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private GameObject _pauseScreen;
        [SerializeField] private CollorCollection _collorCollection;
        [SerializeField] private ScoreSO _scoreSO;
        [SerializeField] private float _startTime = 60f;
        [SerializeField] private ButtonManager _buttonManager;
        private float _countdown = 0f;
        public static Action OnButtonRandomEvent { get; set; }
        public static Action OnColorSelectionEvent { get; set; }

        private void OnEnable()
        {
            GameManager.OnGameStartEvent += Initialize;
            
        }

        private void OnDisable()
        {
            GameManager.OnGameStartEvent -= Initialize;
        }
        

        private void Update()
        {
            ScoreCount();
            Countdown();
        }
        
        private void Initialize()
        {
            _questions.text = _collorCollection.GetQuestion();
            _countdown = _startTime;

            foreach (Transform buttonChild in _buttonManager.transform)
            {
                buttonChild.GetComponent<ButtonHandler>().Inject(this);
            }
        }
        


        private void ScoreCount()
        {
            _scoreText.text = _scoreSO.CurrentScore.ToString();
            _currentScore.text = _scoreSO.CurrentScore.ToString();
            _finalScoreText.text = _scoreSO.CurrentScore.ToString();
            if (_scoreSO.CurrentScore <= 0)
            {
                _scoreSO.CurrentScore = 0;
            }
        }

        private void Countdown()
        {
            //for timer countdown in in the level
            _timerText.text = _countdown.ToString("0");
            _countdown -= 1 * Time.deltaTime;

            if (_countdown <= 0)
            {
                _gameOverScreen.SetActive(true);
                _countdown = 0;
                Debug.Log("GameOver");
            }
        }


        public void CheckAnswers(ColorID SelectedColorID)
        {
            //getting the selected color data in scriptable object 
            if (SelectedColorID == _collorCollection.ColorDataID)
            {
                Debug.Log("CorrectAnswer minus points");
                _feedbacktext.text = "Correct";
                OnColorSelectionEvent.Invoke();
                _scoreSO.CurrentScore++;
                OnButtonRandomEvent?.Invoke();
            }
            else
            {
                Debug.Log("IncorrectAnswer");
                _feedbacktext.text = "InCorrect";
                _scoreSO.CurrentScore--;
                _countdown -= 5f;
            }
        }


        public void MainMenu(string levelName)
        {
            //loads the main menu scene 
            SceneManager.LoadScene(levelName);
            _gameOverScreen.SetActive(false);
        }

        public void TryAgain(string levelName)
        {
            //loads the level 
            SceneManager.LoadScene(levelName);
            _gameOverScreen.SetActive(false);
        }

        public void PauseButton()
        {
            //pausing the game 
         _pauseScreen.SetActive(true);
         Time.timeScale = 0;
        }

        public void PauseBackButton()
        {
            //unpause the game 
            _pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}