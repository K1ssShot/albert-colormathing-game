using UnityEngine;

namespace DATA
{
  [CreateAssetMenu (fileName = "ScoreSO")]
  public class ScoreSO : ScriptableObject
  {
    public int Score = 0;
    public int HighScore = 0;

    public void AddPoints(int ScoreAdd)
    {
    
    }

  }
}
