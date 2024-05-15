using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPlay : MonoBehaviour
{
    public void LoadNextScene()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

