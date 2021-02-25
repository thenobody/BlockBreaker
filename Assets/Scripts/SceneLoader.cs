﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

  public void LoadNextScene()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex + 1);
  }

  public void LoadStartScene()
  {
    SceneManager.LoadScene(0);
  }

  public void LoadGameOverScene()
  {
    SceneManager.LoadScene("Scenes/Game Over");
  }

  public void QuitGame()
  {
    Application.Quit();
  }

}
