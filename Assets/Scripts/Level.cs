using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blockTotal; // Serialized for debugging purposes
    SceneLoader sceneLoader;
    // Start is called before the first frame update

    // when the game starts, find the sceene object
    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    // method to count the blocks on screen tagged with "breakable"
    public void CountBreakableBlocks()
    {
        blockTotal++;

    }
    // when a block is destroyed,
    // decrement the total number of blocks in the Level.
    // If there are no more blocks left, move to the next level
    public void BlockDestroyed()
    {
        blockTotal--;
        if (blockTotal <= 0)
        {
            sceneLoader.LoadNextScene();

        }
    }
}
