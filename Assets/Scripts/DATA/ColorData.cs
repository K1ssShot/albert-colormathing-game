using UnityEngine;
namespace NinetySix.DATA {
     
     // Enumeration to define different color IDs
     public enum ColorID
     {
          Red,
          Blue,
          Green,
          Yellow
     }
     // Serializable class to store color data
     [System.Serializable]
     public class ColorData
     {
          // Enum variable to store color ID
          public ColorID ColorID;
          // String variable to store color name
          public string ColorName;
          // GameObject variable to store color object
          public GameObject Color;
     
     }
}