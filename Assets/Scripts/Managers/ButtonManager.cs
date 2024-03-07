using System;
using System.Collections.Generic;
using DATA;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> _buttonPosition;
        public static Action<ColorID> OnCheckAnswerEvent { get; set; }

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
            _buttonPosition = new List<Transform>();
            foreach ( Transform child  in transform)
            {
                _buttonPosition.Add(child);
               
            }
            RandomButtons();
            
        }
        private void RandomButtons()
        {
            for (int i = 0; i < _buttonPosition.Count; i++)
            {
                //for swapinp possitions in random range in child
                int randomIndex = Random.Range(i, _buttonPosition.Count);
                (_buttonPosition[randomIndex], _buttonPosition[i]) = (_buttonPosition[i], _buttonPosition[randomIndex]);
            }
            // Set the new order of child transforms
            for (int i = 0; i < _buttonPosition.Count; i++)
            {
                _buttonPosition[i].SetSiblingIndex(i);
            }
        }

        
        
        
    }
}
