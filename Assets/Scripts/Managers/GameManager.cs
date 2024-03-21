using System;
using System.Collections.Generic;
using NaughtyAttributes;
using NinetySix.DATA;
using NinetySix.GamePlay;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace NinetySix.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ColorCollectionSO _colorCollectionSO;

        [SerializeField] private List<Transform> _spriteTransformList;

        [SerializeField] private GameObject _shapeprefabGameObject;
        private GameObject _currentSpawnedObject;

        public static Action OnInstantiateButtonEvent { get; set; }
        public static Action OnGameStartEvent { get; set; }


        private void OnEnable()
        {
            UIManager.OnColorSelectionEvent += ColorSelector;
            UIManager.OnDestroyEvent += OnDestroy;
        }

        private void OnDisable()
        {
            UIManager.OnColorSelectionEvent -= ColorSelector;
            UIManager.OnDestroyEvent -= OnDestroy;
        }

        private void Awake()
        {
            foreach (Transform child in transform)
            {
                _spriteTransformList.Add(child);
            }
        }


        private void Start()
        {
            ColorSelector();
            OnInstantiateButtonEvent?.Invoke();
            OnGameStartEvent?.Invoke();
        }


        [Button]
        private void ColorSelector()
        {
            //random the Transform positionlist 
            int randomIndex = UnityEngine.Random.Range(0, _spriteTransformList.Count);
            Transform colorSpawner = _spriteTransformList[randomIndex];
            //getting the scriptableobject method for randoming shape color
            ColorData colorData = _colorCollectionSO.GetRandomColorData();
            _currentSpawnedObject = Instantiate(_shapeprefabGameObject, colorSpawner.position, Quaternion.identity);

            SpriteRenderer spritecolor = _currentSpawnedObject.GetComponent<SpriteRenderer>();
            if (spritecolor != null)
            {
                spritecolor.color = colorData.Colour;
                _colorCollectionSO.ColorDataID = colorData.ColorID;
            }
            else
            {
                Debug.Log("Sprite Renderer or color data is missing ");
            }
            //spawning the new prefabs and deleting upon the selected color is correct
        }
        
        public void OnDestroy()
        {
            if (_currentSpawnedObject != null)
            {
                Destroy(_currentSpawnedObject);
            }
        }


        //_currentColorSpriteObject = Instantiate(colorData.ColorPrefab, colorSpawner.position, Quaternion.identity);
        // handles the color prefabs in game 
        // ColorID = _colorCollectionSO.GetRandomColorID();
        // Debug.Log("randomcolor is seleted " + ColorID);

        // finding the match color in scriptable object and random it 
        // ColorData colorData = _colorCollectionSO.ColorList.Find(x => x.ColorID == ColorID);
        //  Debug.Log($"$ {ColorID} is Selected-{colorData.ColorID}");
    }
}