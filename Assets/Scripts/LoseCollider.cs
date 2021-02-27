using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{

  // references
  private SceneLoader sceneLoader;

  void Start()
  {
    sceneLoader = FindObjectOfType<SceneLoader>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    sceneLoader.LoadGameOverScene();
  }

}
