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
            UIManager.OnButtonRandomEvent += ShuffleButtons;
        }

        private void OnDisable()
        {
            UIManager.OnButtonRandomEvent -= ShuffleButtons;
        }


        private void ShuffleButtons()
        {
            //getting the position of child in parent 
            _buttonPositionList = new List<Transform>();
            foreach ( Transform child  in transform)
            {
                _buttonPositionList.Add(child);
               
            }
            RandomButtons();
            
        }
        private void RandomButtons()
        {
            for (int i = 0; i < _buttonPositionList.Count; i++)
            {
                //for Getting random possitions in random range in child
                int randomIndex = Random.Range(i, _buttonPositionList.Count);
                
                //positioning the random position
                _buttonPositionList[i] = _buttonPositionList[randomIndex];
                Debug.Log($"{i} {_buttonPositionList.Count}");
                
            }
            // Set the new order of child transforms
            for (int i = 0; i < _buttonPositionList.Count; i++)
            {
                _buttonPositionList[i].SetSiblingIndex(i);
            }
        }

        
        
        
    }
}
