using UnityEngine;

namespace DATA
{
  
  [CreateAssetMenu (fileName = "ScoreSO")]
  public class ScoreSO : ScriptableObject
  {
    // Public variables to store current score and high score
    public int Score = 0;
    public int HighScore = 0;

    // Method to add points to the score
    public void AddPoints(int ScoreAdd)
    {
      // Implementation of adding points to the score
      
    }

  }
}
