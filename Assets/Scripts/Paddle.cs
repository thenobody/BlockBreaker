using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour
{
  // references
  private GameSession gameSession;
  private Camera currentCamera;
  private Ball ball;

  void Start()
  {
    gameSession = FindObjectOfType<GameSession>();
    currentCamera = Camera.main;
    ball = FindObjectOfType<Ball>();
  }

  // Update is called once per frame
  void Update()
  {
    float xNextPosition = GetXPosition();
    float yNextPosition = transform.position.y;

    transform.position = new Vector2(xNextPosition, yNextPosition);
  }

  public float GetXPosition()
  {
    float maxWidth = currentCamera.orthographicSize * currentCamera.aspect * 2;

    float xPosition = gameSession.IsAutoPlayEnabled() ? ball.transform.position.x : currentCamera.ScreenToWorldPoint(Input.mousePosition).x;
    return Mathf.Clamp(xPosition, 1, maxWidth - 1);
  }
}
