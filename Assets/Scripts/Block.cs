using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

  // config
  [SerializeField] private int maxHits;
  [SerializeField] private AudioClip destroyAudioClip;
  [SerializeField] private GameObject blockSparklesVFX;
  [SerializeField] private Sprite[] hitSprites;

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
    if (gameObject.tag == "Breakable")
    {
      HandleHit(collision);
    }
  }

  private void HandleHit(Collision2D collision)
  {
    hits++;
    if (hits >= maxHits)
    {
      DestroyBlock();
    }
    else
    {
      ShowNextHitSprite();
    }
  }

  private void ShowNextHitSprite()
  {
    GetComponent<SpriteRenderer>().sprite = hitSprites[hits - 1];
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
    var sparkles = Instantiate(blockSparklesVFX, gameObject.transform.position, gameObject.transform.rotation);
    Destroy(sparkles, 1f);
  }
}
