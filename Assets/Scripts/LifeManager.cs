using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;
    public TextMeshProUGUI livesText;

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
        Player.OnDamage += UpdateUI;
    }

    private void UpdateUI(int currentLives)
    {
        livesText.text = currentLives.ToString();
    }
}
