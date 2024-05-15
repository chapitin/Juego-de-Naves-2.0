using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public const string pointsKey = "TIMES_POINTS";

    public static PointsManager instance;
    public Text pointsText;

    [SerializeField] private int currentScore = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        Enemy.OnDead += HandleEnemyDeath;
        ComplexEnemy.OnDead += HandleEnemyDeath;
    }

 
    private void HandleEnemyDeath(int points)
    {
        currentScore += points;
        UpdateUI();
    }

    private void UpdateUI()
    {
        pointsText.text = currentScore.ToString();
    }

    private void HandleSavePoints()
    {
        int highestScore = PlayerPrefs.GetInt(pointsKey, 0);
        

        if (currentScore > highestScore)
        {
            PlayerPrefs.SetInt(pointsKey, currentScore);
            PlayerPrefs.Save(); 
        }
    }
}
