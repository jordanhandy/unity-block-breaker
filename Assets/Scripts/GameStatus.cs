using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //Config parameters
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoplayEnabled;


    //State variables
    [SerializeField] int currentScore = 0;
    // Start is called before the first frame update

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            // Because Destroy is the last activity in the execution order,
            // fractions of a second can occur when the gameObject is not destroyed.
            // This ensures it is inactive before it is destroyed
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        // set the current score at game start
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // set the game speed based on the speed set
        Time.timeScale = gameSpeed;

    }
    public void AddToScore()
    {
        // add to the user's current score based on when a block is destroyed
        currentScore += pointsPerBlockDestroyed;
        // text is updated on screen
        scoreText.text = currentScore.ToString();

    }
    // At game reset, destroy this game object, and create a new one
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    // checking if autoplay is enabled
    // used for debugging purposed to auto play the game
    public bool IsAutoPlayEnabled()
    {
        return isAutoplayEnabled;
    }
}
