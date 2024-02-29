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
    
   
        public void ColorSelector(ColorID colorID = ColorID.random)
        {
            if (colorID == ColorID.random)
            {
                colorID = QuizSO.GetrandomColor(QuizSO.ColorList);
                Debug.Log("randomcolor is seleted " + colorID);
            }
            var ColorData = QuizSO.ColorList.Find(x => x.ColorID == colorID);
            Debug.Log($"$Color is Selected{colorID}-{ColorData.ColorID}");
            int randomindex = UnityEngine.Random.Range(0, _spriteSpawner.Count);
            Transform colorspawner = _spriteSpawner[randomindex];

            QuizSO.ColorDataID = colorID;

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

