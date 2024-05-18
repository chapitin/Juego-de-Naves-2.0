using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
  public TextMeshProUGUI highScoreText;

  void Start()
  {
      DisplayHighScore();
  }

  void DisplayHighScore()
  {
      print("points manager method" + PointsManager.savedPoints.ToString());

      highScoreText.text = "High Score: " + PointsManager.savedPoints.ToString();

      print("hightextscore:" + highScoreText.text);
  }
}
