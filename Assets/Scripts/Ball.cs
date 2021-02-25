using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

  // config parameters
  [SerializeField] Paddle paddle;
  [SerializeField] Vector2 initialVelocity;

  // state
  private Vector2 paddleDistance;
  // Start is called before the first frame update
  void Start()
  {
    paddleDistance = transform.position - paddle.transform.position;
    GetComponent<Rigidbody2D>().simulated = false;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButton(0))
    {
      GetComponent<Rigidbody2D>().simulated = true;
      GetComponent<Rigidbody2D>().velocity = initialVelocity;
    }
    else if (!GetComponent<Rigidbody2D>().simulated)
    {
      Vector2 paddlePosition = paddle.transform.position;
      transform.position = paddlePosition + paddleDistance;
    }
  }
}
