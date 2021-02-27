using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
  // state
  private int blockCount;
  private SceneLoader sceneLoader;

  // Start is called before the first frame update
  void Start()
  {
    blockCount = 0;
    sceneLoader = FindObjectOfType<SceneLoader>();
  }

  public void IncrementBlockCount()
  {
    blockCount++;
  }

  public void DecrementBlockCount()
  {
    blockCount--;
    CheckVictory();
  }

  public void CheckVictory()
  {
    if (blockCount <= 0)
    {
      sceneLoader.LoadNextScene();
    }
  }


}
