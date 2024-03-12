using NinetySix.DATA;
using NinetySix.Managers;
using UnityEngine;

namespace NinetySix.GamePlay
{
    public class ButtonHandler : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private ColorID _colorID ;

        public void OnClickButton()
        {
            // once button is clicked by selecting the correct color 
            _uiManager.CheckAnswers(_colorID);
            Debug.Log($"Correct" + _colorID);
        }

        public void InjectUIManager(UIManager uiManager)
        {
            //injecting this method to the UIManager 
            _uiManager = uiManager;
        }
    
    }
}
