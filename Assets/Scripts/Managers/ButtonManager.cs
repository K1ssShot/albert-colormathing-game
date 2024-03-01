using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _buttonObjectList;
        [SerializeField] private List<Transform> _buttonPosition;
        [SerializeField] private List<GameObject> _lastInstantiatedButton = new List<GameObject>();
        [SerializeField] private List<int> _newInt; 
    
        private void Awake()
        {
            ButtonToShuffle();
        }

        [Button]
        public void TestShuffle()
        {
            _newInt.Shuffle();
        }

        [Button]
        public void ButtonToShuffle()
        {
            List<Transform> availablePosition = new List<Transform>(_buttonPosition);

            // foreach (GameObject button in _lastInstantiatedButton)
            // {
            //     Destroy(button);
            // }
            // _lastInstantiatedButton.Clear();

            foreach (Transform child in transform)
            {
                Destroy(child);
            }
        
            foreach (var buttonprefab in _buttonObjectList)
            {
          
                //to avoid duplicate button possition
                if (availablePosition.Count == 0)
                {
                    Debug.Log("not enough position for all buttons");
                    return;
                }
                //Random
                int randomIndex = Random.Range(0, availablePosition.Count);
                var buttonsPosition = availablePosition[randomIndex];
                //Instantiate
                var currentButton = Instantiate(buttonprefab, gameObject.transform);
                currentButton.transform.position = buttonsPosition.position;
               // _lastInstantiatedButton.Add(currentButton);
                availablePosition.RemoveAt(randomIndex);
                
           
            }

            Debug.Log("All Button is shuffled");
        }
        
    }
}
