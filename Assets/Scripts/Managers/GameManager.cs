using System.Collections.Generic;
using DATA;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
    
        [SerializeField] private TextMeshProUGUI _timertext;
        [SerializeField] private QuizSO QuizSO;
        [SerializeField] private List<Transform> _spriteSpawner;
        private GameObject _currentColorSprite;
        public ColorID ColorSelection;
        
        private void Start()
        {
            ColorSelector();
        }
    
   
        public void ColorSelector()
        {
            ColorSelection = QuizSO.GetrandomColor();
                Debug.Log("randomcolor is seleted " + ColorSelection);
            
            var ColorData = QuizSO.ColorList.Find(x => x.ColorID == ColorSelection);
            Debug.Log($"$Color is Selected{ColorSelection}-{ColorData.ColorID}");
            int randomindex = UnityEngine.Random.Range(0, _spriteSpawner.Count);
            Transform colorspawner = _spriteSpawner[randomindex];

            QuizSO.ColorDataID = ColorSelection;

            if (ColorData != null)
            {
                if (_currentColorSprite != null)
                {
                    Destroy(_currentColorSprite);
                }
            }
        
            _currentColorSprite = Instantiate(ColorData.Color, colorspawner.position, Quaternion.identity);

        }
    
    
    }
}    

