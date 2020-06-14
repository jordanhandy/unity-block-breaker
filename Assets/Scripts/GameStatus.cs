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
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

    }
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();

    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoplayEnabled;
    }
}
