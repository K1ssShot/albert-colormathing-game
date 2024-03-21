using System;
using NaughtyAttributes;
using NinetySix.DATA;
using NinetySix.GamePlay;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


namespace NinetySix.Managers
{
    public class UIManager : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI _questionsText;
        [SerializeField] private TextMeshProUGUI _feedbackText;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _finalScoreText;
        [SerializeField] private TextMeshProUGUI _currentScoreText; 
        [SerializeField] private GameObject _gameOverScreenObject;
        [SerializeField] private GameObject _pauseScreenObject;
        [SerializeField] private ColorCollectionSO _colorCollectionSO;
        [SerializeField] private ScoreSO _scoreSO;
        [SerializeField] private float _startTime = 60;
        public Transform _buttonContainer;
         private float _countdown = 0f;
        public static Action OnDestroyEvent { get; set; }
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
        [Button]
        private void Initialize()
        {
            _questionsText.text = _colorCollectionSO.GetQuestion();
            _countdown = _startTime;

             foreach (Transform buttonChild in _buttonContainer.transform)
             {
                 buttonChild.GetComponent<ButtonHandler>().InjectUIManager(this);
             }
        }
        


        private void ScoreCount()
        {
            _scoreText.text = _scoreSO.CurrentScore.ToString();
            _currentScoreText.text = _scoreSO.CurrentScore.ToString();
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
                _gameOverScreenObject.SetActive(true);
                _countdown = 0;
                Debug.Log("GameOver");
            }
        }
        
        


        public void CheckAnswers(ColorID selectedColorID)
        {
            //getting the selected color data in scriptable object 
            if (selectedColorID == _colorCollectionSO.ColorDataID)
            {
                Debug.Log("CorrectAnswer plus points");
                _feedbackText.text = "Correct";
                _scoreSO.CurrentScore++;
                RandomButtons();
                OnDestroyEvent?.Invoke();
                OnColorSelectionEvent?.Invoke();
                
            }
            else
            {
                Debug.Log("IncorrectAnswer minus points");
                _feedbackText.text = "InCorrect";
                _scoreSO.CurrentScore--;
                _countdown -= 5f;
            }
        }


        public void MainMenu(string levelName)
        {
            
            //loads the main menu scene 
            SceneManager.LoadScene(levelName);
            _gameOverScreenObject.SetActive(false);
        }

        public void TryAgain(string levelName)
        {
            _scoreSO.CurrentScore = 0;
            //loads the level 
            SceneManager.LoadScene(levelName);
            _gameOverScreenObject.SetActive(false);
            
        }

        public void PauseButton()
        {
            //pausing the game 
         _pauseScreenObject.SetActive(true);
         Time.timeScale = 0;
        }

        public void PauseBackButton()
        {
            //unpause the game 
            _pauseScreenObject.SetActive(false);
            Time.timeScale = 1;
        }
        public void RandomButtons() 
        {
            for (int i = 0; i < _buttonContainer.childCount; i++)
            {
                //for Getting random index within the range of child elemernts
                int randomIndex = Random.Range(i, _buttonContainer.childCount);
                //getting the child transform at the random index
                Transform childTransform = _buttonContainer.GetChild(randomIndex);
                //setting the siblings index of the child transform to the current index 
                childTransform.SetSiblingIndex(i);
               // Debug.Log($"{i}");
                
            }
        }
        
        public void TestRandomRange()
        {
            int min = 0;
            int max = 5;
            int result = max + 1 - Random.Range(min, max + 1);
            
            Debug.Log($"{result}");
        }
    }
}