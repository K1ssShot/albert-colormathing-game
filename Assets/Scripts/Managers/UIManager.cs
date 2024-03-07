using System;
using DATA;
using GamePlay;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private QuizSO QuizSO;
        [SerializeField] private ScoreSO _scoreSO;
        [SerializeField] private float _startTime = 60f;
        [SerializeField] private ButtonManager _buttonManager;
        private float _countdown = 0f;
        public static Action OnButtonRandomEvent { get; set; }

        private void OnEnable()
        {
            GameManager.OnGameStartEvent += Initialize;
        }

        private void OnDisable()
        {
            GameManager.OnGameStartEvent -= Initialize;
        }

        private void Initialize()
        {
            _questions.text = QuizSO.GetQuestion();
            _countdown = _startTime;

            foreach (Transform buttonChild in _buttonManager.transform)
            {
                buttonChild.GetComponent<ButtonHandler>().Inject(this);
            }
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
            if (_scoreSO.Score <= 0)
            {
                _scoreSO.Score = 0;
            }
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


        public void CheckAnswers(ColorID SelectedColorID)
        {
            if (SelectedColorID == QuizSO.ColorDataID)
            {
                Debug.Log("CorrectAnswer minus points");
                _feedbacktext.text = "Correct";
                _gameManager.ColorSelector();
                _scoreSO.Score++;
                OnButtonRandomEvent?.Invoke();
                //todo put an observer pattern here;
            }
            else
            {
                Debug.Log("IncorrectAnswer");
                _feedbacktext.text = "InCorrect";
                _scoreSO.Score--;
                _countdown -= 5f;
            }
        }


        public void MainMenu(string levelName)
        {
            SceneManager.LoadScene(levelName);
            _gameOverScreen.SetActive(false);
        }

        public void TryAgain(string levelName)
        {
            SceneManager.LoadScene(levelName);
            _gameOverScreen.SetActive(false);
        }
    }
}