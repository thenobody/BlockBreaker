using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

  // config parameters
  [SerializeField] Paddle paddle;
  [SerializeField] Vector2 initialVelocity;
  [Range(0f, 10f)] [SerializeField] private float velocityRandomness;
  [SerializeField] AudioClip[] audioClips;
  // state
  private Rigidbody2D ballRigidbody;
  private AudioSource ballAudioSource;
  private Vector2 paddleDistance;
  // Start is called before the first frame update
  void Start()
  {
    paddleDistance = transform.position - paddle.transform.position;
    ballRigidbody = GetComponent<Rigidbody2D>();
    ballAudioSource = GetComponent<AudioSource>();

    ballRigidbody.simulated = false;
  }

  void Update()
  {
    if (!ballRigidbody.simulated)
    {
      LockBallToPaddle();
      LaunchOnClick();
    }
  }

  private void LockBallToPaddle()
  {
    Vector2 paddlePosition = paddle.transform.position;
    transform.position = paddlePosition + paddleDistance;
  }

  private void LaunchOnClick()
  {
    if (Input.GetMouseButtonUp(0))
    {
      ballRigidbody.simulated = true;
      ballRigidbody.velocity = initialVelocity;
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    var clip = GetRandomAudioClip();
    ballAudioSource.PlayOneShot(GetRandomAudioClip());
    IncreaseVelocity();
  }

  private AudioClip GetRandomAudioClip()
  {
    int index = Random.Range(0, audioClips.Length);
    return audioClips[index];
  }

  public void IncreaseVelocity()
  {
    Vector2 randomVector = new Vector2(Random.Range(0f, velocityRandomness), Random.Range(0f, velocityRandomness));
    ballRigidbody.velocity += randomVector;
  }
}
