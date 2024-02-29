using UnityEngine;

namespace DATA {
     public enum ColorID
     {
          Red,
          Blue,
          Green,
          Yellow,
          random
     }


     [System.Serializable]
     public class ColorData
     {
          public ColorID ColorID;
          public string ColorName;
          public GameObject Color;
     
     }
}