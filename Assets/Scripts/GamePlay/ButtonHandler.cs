using DATA;
using Managers;
using UnityEngine;

namespace GamePlay
{
    public class ButtonHandler : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private ColorID _colorID ;

        public void OnClickButton()
        {
            _uiManager.CheckAnswers(_colorID);
            Debug.Log($"Correct" + _colorID);
        }

        public void Inject(UIManager uiManager)
        {
            _uiManager = uiManager;
        }
    
    }
}
