using System;
using System.Collections.Generic;
using NinetySix.DATA;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace NinetySix.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private ColorCollection _colorCollection;
        [SerializeField] private List<Transform> _spriteSpawnerList;
        [SerializeField] private GameObject _currentColorSpriteObject;
        [FormerlySerializedAs("ColorSelection")] public ColorID ColorID;
        public static Action OnGameStartEvent { get; set; }

        private void OnEnable()
        {
            UIManager.OnColorSelectionEvent += ColorSelector;

        }

        private void OnDisable()
        {
            UIManager.OnColorSelectionEvent -= ColorSelector;
        }


        private void Start()
        {
            ColorSelector();
            OnGameStartEvent?.Invoke();
        }


        public void ColorSelector()
        {
            // handles the color prefabs in game 
            ColorID = _colorCollection.GetRandomColorData();
            Debug.Log("randomcolor is seleted " + ColorID);
            
            // finding the match color in scriptable object and random it 
            ColorData colorData = _colorCollection.ColorList.Find(x => x.ColorID == ColorID);
            Debug.Log($"$Color is Selected{ColorID}-{colorData.ColorID}");
            
            int randomIndex = UnityEngine.Random.Range(0, _spriteSpawnerList.Count);
            Transform colorSpawner = _spriteSpawnerList[randomIndex];

            _colorCollection.ColorDataID = ColorID;

            if (colorData != null)
            {
                //spawning the new prefabs and deleting upon the selected color is correct
                if (_currentColorSpriteObject != null)
                {
                    Destroy(_currentColorSpriteObject);
                }
            }

            _currentColorSpriteObject = Instantiate(colorData.Color, colorSpawner.position, Quaternion.identity);
        }
    }
}