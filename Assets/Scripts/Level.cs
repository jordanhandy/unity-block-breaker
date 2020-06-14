using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blockTotal; // Serialized for debugging purposes
    SceneLoader sceneLoader;
    // Start is called before the first frame update

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableBlocks()
    {
        blockTotal++;

    }
    public void BlockDestroyed()
    {
        blockTotal--;
        if (blockTotal <= 0)
        {
            sceneLoader.LoadNextScene();

        }
    }
}
