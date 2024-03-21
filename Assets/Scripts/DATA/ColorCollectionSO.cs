using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace NinetySix.DATA
{
    [CreateAssetMenu (fileName = "CollorCollectionSO")]
    // ScriptableObject to store quiz data
    public class ColorCollectionSO : ScriptableObject
    {
        // List to store ColorData objects
        [SerializeField] private List<ColorData> ColorList;
        // Variable to store the ID of the ColorData
        public ColorID ColorDataID;
        // Serialized field to store the question text, with a TextArea attribute for better editor display
        [FormerlySerializedAs("Question")]
        [TextArea(1,6)] 
        [SerializeField] private string _question = "Enter Question text ";

        //[SerializeField] private Color32 hasColor;
        public string GetQuestion()
        {
            //Getting Question for the scriptable Object
            return _question;
        }

        // public ColorChange(Color32 color)
        // {
        //     //getting the Random Color in enum
        //    // return ColorList[Random.Range(0, ColorList.Count)].ColorID;
        //    
        // }

        public ColorData GetRandomColorData()
        {
            return ColorList[Random.Range(0,ColorList.Count)];
            
        }

        // public ColorData ColorChanger()
        // {
        //     
        // }
        
      

    }
}
