using System;
using System.Collections.Generic;
using NinetySix.DATA;
using NaughtyAttributes;
using NinetySix.GamePlay;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace NinetySix.Managers
{
    public class ButtonContainer : MonoBehaviour
    {
      //  [SerializeField] private List<Transform> _buttonPositionList;
        [SerializeField] private List<GameObject> _buttonPrefab;
        [SerializeField] private Transform _ButtonContainer;
        
        private void OnEnable()
        {
            GameManager.OnInstantiateButtonEvent += AddButton;
        }

        private void OnDisable()
        {
           
            GameManager.OnInstantiateButtonEvent -= AddButton;
        }
        
   
        [Button]
        private void AddButton()
        {
            //  GameObject NewButton = Instantiate(_buttonPrefab, _ButtonContainer);
            if (_buttonPrefab.Count == 0)
            {
                Debug.Log("Button prefabs is empty ");
                return;       
            }
            foreach (GameObject buttonPrefabs in _buttonPrefab)
            {
               GameObject button = Instantiate(buttonPrefabs, _ButtonContainer);
              // ButtonHandler buttonHandler = button.GetComponent<ButtonHandler>();
              // buttonHandler._colorID = button
            }

            if (_ButtonContainer.childCount <= 5)
                return;
            var layoutGroup = _ButtonContainer.GetComponent<HorizontalLayoutGroup>();
            if (layoutGroup == null)
            {
                layoutGroup.childControlWidth = false;
                layoutGroup.spacing = 10f;
            }
            else
            {
                Debug.Log("Horizontal Layoutgroup containter not found in button container ");
            }
        }
        
        
        
        
        
        
        
        // private void RandomButtons() 
        // {
        //     for (int i = 0; i < transform.childCount; i++)
        //     {
        //         //for Getting random index within the range of child elemernts
        //         int randomIndex = Random.Range(i, transform.childCount);
        //         //getting the child transform at the random index
        //         Transform childTransform = transform.GetChild(randomIndex);
        //         //setting the siblings index of the child transform to the current index 
        //         childTransform.SetSiblingIndex(i);
        //         // Debug.Log($"{i} {_buttonPositionList.Count}");
        //         
        //         //positioning the random position
        //        // _buttonPositionList[randomIndex] = _buttonPositionList[i];
        //       //  _buttonPositionList[i] = _buttonPositionList[randomIndex];
        //         
        //     }
        //     // Set the new order of child transforms
        //     // for (int i = 0; i < _buttonPositionList.Count; i++)
        //     // {
        //     //     _buttonPositionList[i].SetSiblingIndex(i);
        //     // }
        // }
        
     // private void GetButtons()
        // {
        //     //getting the position of child in parent 
        //      _buttonPositionList = new List<Transform>();
        //      foreach ( Transform child  in transform)
        //      {
        //         _buttonPositionList.Add(child);
        //         
        //      }
        //     //RandomButtons();
        //     
        // }
    }
}
