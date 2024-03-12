using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace NinetySix.DATA
{
    [CreateAssetMenu (fileName = "CollorCollectionSO")]
    // ScriptableObject to store quiz data
    public class ColorCollection : ScriptableObject
    {
        // List to store ColorData objects
        public List<ColorData> ColorList;
        // Variable to store the ID of the ColorData
        public ColorID ColorDataID;
        // Serialized field to store the question text, with a TextArea attribute for better editor display
        [FormerlySerializedAs("Question")]
        [TextArea(1,6)] 
        [SerializeField] private string _question = "Enter Question text ";
        public string GetQuestion()
        {
            //Getting Question for the scriptable Object
            return _question;
        }

        public ColorID GetRandomColorData()
        {
            //getting the Random Color in enum
            return ColorList[Random.Range(0, ColorList.Count)].ColorID;
            
        }
      

    }
}
