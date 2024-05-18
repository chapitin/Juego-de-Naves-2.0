using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButton : MonoBehaviour
{
    private int gameSceneIndex = 1;

    public void PlayAgain()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }
}
