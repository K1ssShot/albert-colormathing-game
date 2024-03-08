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
        [SerializeField] private TextMeshProUGUI _timertext;
        [SerializeField] private CollorCollection _collorCollection;
        [SerializeField] private List<Transform> _spriteSpawner;
        private GameObject _currentColorSprite;
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
            ColorSelection = _collorCollection.GetRandomColorData();
            Debug.Log("randomcolor is seleted " + ColorSelection);
            // finding the match color in scriptable object and random it 
            var colorData = _collorCollection.ColorList.Find(x => x.ColorID == ColorSelection);
            Debug.Log($"$Color is Selected{ColorSelection}-{colorData.ColorID}");
            int randomIndex = UnityEngine.Random.Range(0, _spriteSpawner.Count);
            Transform colorspawner = _spriteSpawner[randomIndex];

            _collorCollection.ColorDataID = ColorSelection;

            if (colorData != null)
            {
                //spawning the new prefabs and deleting upon the selected color is correct
                if (_currentColorSprite != null)
                {
                    Destroy(_currentColorSprite);
                }
            }

            _currentColorSprite = Instantiate(colorData.Color, colorspawner.position, Quaternion.identity);
        }
    }
}