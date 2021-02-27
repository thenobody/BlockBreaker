using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
  // config
  [Range(0.1f, 20.0f)] [SerializeField] float gameSpeed = 1;
  [SerializeField] TMPro.TMP_Text scoreText;
  [SerializeField] int blockDestroyedPoints = 83;

  //state
  int score = 0;
  // Update is called once per frame

  void Awake()
  {
    int instanceCount = FindObjectsOfType<GameSession>().Length;
    if (instanceCount > 1)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }

  void Update()
  {
    Time.timeScale = gameSpeed;
    scoreText.text = score.ToString();
  }

  public void AddBlockDestroyedPoints()
  {
    score += blockDestroyedPoints;
  }

  public void ResetGame()
  {
    Destroy(gameObject);
  }
}
