using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public string nextLevelName = "Level2";

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
