using System.Collections.Generic;
using UnityEngine;

namespace DATA
{
    [CreateAssetMenu (fileName = "QuestionMaker")]
    // ScriptableObject to store quiz data
    public class QuizSO : ScriptableObject
    {
        // List to store ColorData objects
        public List<ColorData> ColorList;
        // Variable to store the ID of the ColorData
        public ColorID ColorDataID;
        // Serialized field to store the question text, with a TextArea attribute for better editor display
        [TextArea(1,6)] 
        [SerializeField] private string Question = "Enter Question text ";
        public string GetQuestion()
        {
            return Question;
        }

        public ColorID GetrandomColor()
        {
            return ColorList[Random.Range(0, ColorList.Count)].ColorID;
        }
      

    }
}
