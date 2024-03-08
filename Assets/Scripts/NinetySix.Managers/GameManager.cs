using System;
using System.Collections.Generic;
using NinetySix.DATA;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private ColorCollection _colorCollection;
        [SerializeField] private List<Transform> _spriteSpawnerList;
        private GameObject _currentColorSpriteObject;
        public ColorID ColorSelection;
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
            ColorSelection = _colorCollection.GetRandomColorData();
            Debug.Log("randomcolor is seleted " + ColorSelection);
            // finding the match color in scriptable object and random it 
            var colorData = _colorCollection.ColorList.Find(x => x.ColorID == ColorSelection);
            Debug.Log($"$Color is Selected{ColorSelection}-{colorData.ColorID}");
            int randomIndex = UnityEngine.Random.Range(0, _spriteSpawnerList.Count);
            Transform colorSpawner = _spriteSpawnerList[randomIndex];

            _colorCollection.ColorDataID = ColorSelection;

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