using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    // Start is called before the first frame update

    public void Play(string levelName)
    {
        SceneManager.LoadScene(levelName);

    }
}
