using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Camera camera = Camera.main;
    Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);
    float maxWidth = camera.orthographicSize * camera.aspect * 2;
    float xNextPosition = Mathf.Clamp(position.x, 1, maxWidth - 1);
    float yNextPosition = transform.position.y;

    transform.position = new Vector2(xNextPosition, yNextPosition);
  }
}
