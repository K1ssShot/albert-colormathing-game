using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class Testing : MonoBehaviour
{
   [SerializeField] private List<GameObject> _buttonPrefab;
   [SerializeField] private Transform _ButtonContainer;

   [Button]
   public void AddButton()
   {
    //  GameObject NewButton = Instantiate(_buttonPrefab, _ButtonContainer);
    if (_buttonPrefab.Count == 0)
    {
       Debug.Log("Button prefabs is empty ");
      return;       
    }

    foreach (GameObject buttonPrefabs in _buttonPrefab)
    {
       Instantiate(buttonPrefabs, _ButtonContainer);
    }


    if (_ButtonContainer.childCount <= 4)
       return;
    HorizontalLayoutGroup layoutGroup = _ButtonContainer.GetComponent<HorizontalLayoutGroup>();
      if (layoutGroup == null)
      {
         layoutGroup.childControlWidth = false;
         layoutGroup.spacing = 10f; 
      }
      else
      {
         Debug.Log("Horizontal Layoutgroup containter not found in button container ");
      }
         

      LayoutElement[] buttons = _ButtonContainer.GetComponentsInChildren<LayoutElement>();
      foreach (LayoutElement button in buttons)
      {
         button.preferredWidth -= 10f;
      }
   }
}
