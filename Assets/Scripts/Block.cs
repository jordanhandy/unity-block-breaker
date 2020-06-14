using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Class references
    Level level;

    //state variables
    GameStatus gameStatus;
    [SerializeField] int timesHit;  // TODO only serialized for debug purposes

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSrpite();
            }
        }
    }
    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
        gameStatus.AddToScore();
    }
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.5f);

    }
    private void ShowNextHitSrpite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];

        }
        else
        {
            Debug.LogError("Block sprite is missing from array! " + gameObject.name);
        }

    }
}
