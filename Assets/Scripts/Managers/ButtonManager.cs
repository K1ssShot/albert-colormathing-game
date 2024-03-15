using System;
using System.Collections.Generic;
using NinetySix.DATA;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace NinetySix.Managers
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> _buttonPositionList;
        
        private void OnEnable()
        {
            UIManager.OnButtonRandomEvent += GetButtons;
        }

        private void OnDisable()
        {
            UIManager.OnButtonRandomEvent -= GetButtons;
        }


        private void GetButtons()
        {
            //getting the position of child in parent 
            // _buttonPositionList = new List<Transform>();
            // foreach ( Transform child  in transform)
            // {
            //     _buttonPositionList.Add(child);
            //    
            // }
            RandomButtons();
            
        }
        private void RandomButtons() 
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                //for Getting random index within the range of child elemernts
                int randomIndex = Random.Range(i, transform.childCount);
                //getting the child transform at the random index
                Transform childTransform = transform.GetChild(randomIndex);
                //setting the siblings index of the child transform to the current index 
                childTransform.SetSiblingIndex(i);
                // Debug.Log($"{i} {_buttonPositionList.Count}");
                
                //positioning the random position
               // _buttonPositionList[randomIndex] = _buttonPositionList[i];
              //  _buttonPositionList[i] = _buttonPositionList[randomIndex];
                
            }
            // Set the new order of child transforms
            // for (int i = 0; i < _buttonPositionList.Count; i++)
            // {
            //     _buttonPositionList[i].SetSiblingIndex(i);
            // }
        }

        
        
        
    }
}
