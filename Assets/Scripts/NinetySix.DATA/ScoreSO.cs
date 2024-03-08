using UnityEngine;
using UnityEngine.Serialization;

namespace NinetySix.DATA
{
  
  [CreateAssetMenu (fileName = "ScoreSO")]
  public class ScoreSO : ScriptableObject
  {
    // Public variables to store current score and high score
    public int CurrentScore = 0;
    public int HighScore = 0;

    // Method to add points to the score
    public void AddPoints(int scoreToAdd)
    {
      CurrentScore += scoreToAdd;
      if (CurrentScore > HighScore)
      {
        HighScore = CurrentScore;
      }

    }

  }
}
