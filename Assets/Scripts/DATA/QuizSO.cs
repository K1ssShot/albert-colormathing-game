using System.Collections.Generic;
using UnityEngine;

namespace DATA
{
    [CreateAssetMenu (fileName = "QuestionMaker")]
    public class QuizSO : ScriptableObject
    {
        public List<ColorData> ColorList;
        public ColorID ColorDataID;
        [TextArea(1,6)] 
        [SerializeField] private string Question = "Enter Question text ";
    

        public string GetQuestion()
        {
            return Question;
        }
    
    
        public  ColorID GetrandomColor(List<ColorData> colorlist)
        {
            if (colorlist == null || colorlist.Count == 0)
            {
                Debug.LogWarning("ColorList is empty, returning to default color ");
                return ColorID.Red;
            }

            int randomindex = UnityEngine.Random.Range(0, colorlist.Count);
            return colorlist[randomindex].ColorID;
        }

        public ColorID GetrandomColor()
        {

            return ColorList[Random.Range(0, ColorList.Count)].ColorID;
        }
    
        public string GetAnswers(int i)
        {
            return null;
        }
      

    }
}
