using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

  // config
  [SerializeField] private int maxHits;
  [SerializeField] private float velocityMultiplier;
  [SerializeField] private AudioClip destroyAudioClip;
  [SerializeField] private GameObject blockSparklesVFX;

  // state
  private int hits;

  // references
  private Level level;
  private GameSession gameState;

  // Start is called before the first frame update
  void Start()
  {
    hits = 0;
    gameState = FindObjectOfType<GameSession>();
    CountBreakableBlocks();
  }

  private void CountBreakableBlocks()
  {
    level = FindObjectOfType<Level>();
    if (gameObject.tag == "Breakable")
    {
      level.IncrementBlockCount();
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    hits++;
    if (gameObject.tag == "Breakable")
    {
      collision.gameObject.GetComponent<Ball>().IncreaseVelocity(velocityMultiplier);
      if (hits >= maxHits)
      {
        DestroyBlock();
      }
      else
      {
        Color currentColor = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = Color.Lerp(currentColor, Color.black, 0.5f);
      }
    }
  }

  private void DestroyBlock()
  {
    AudioSource.PlayClipAtPoint(destroyAudioClip, Camera.main.transform.position);
    TriggerSparklesVFS();
    Destroy(gameObject);
    level.DecrementBlockCount();
    gameState.AddBlockDestroyedPoints();
  }

  private void TriggerSparklesVFS()
  {
    Instantiate(blockSparklesVFX, gameObject.transform.position, gameObject.transform.rotation);
  }
}
