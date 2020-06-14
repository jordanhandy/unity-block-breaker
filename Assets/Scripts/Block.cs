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
    // to count the number of times a block has been hit
    [SerializeField] int timesHit;  // TODO only serialized for debug purposes

    private void Start()
    {
        // grab the game state and level objects
        // count the number of breakable blocks on scene
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the block is breakable,
        // increase the number of times the block has been hit
        // at each hit, the sprite will change.  The number of hits is only as large 
        // as the array of sprites to choose from at each hit

        // If no sprites left in the array, destroy the block
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            // if still hits left in array, show the next sprite on hit
            else
            {
                ShowNextHitSrpite();
            }
        }
    }
    // when a block is destroyed, play the sound from the camera source,
    // destroy the block
    // Call the BlockDestroyed method from the Level Script (see Level script for use)
    // add to the player score
    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
        // see Game Status script for this method information
        gameStatus.AddToScore();
    }
    // particle effects for when a block is destroyed
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.5f);

    }
    // Method to show the next sprite when an object is hit
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
