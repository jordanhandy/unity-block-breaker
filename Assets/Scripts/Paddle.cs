using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.mousePosition.x);
        // Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);

        // Clamp the paddle to the edges of the screen
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePosition;

    }
    // For moving the mouse with the paddle.
    // If auto play is enabled, then the x Position of the paddle will be exactly the
    // x position of the ball, so that the auto play cannot lose
    private float GetXPos()
    {
        if (FindObjectOfType<GameStatus>().IsAutoPlayEnabled())
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
            // Otherwise, return the mouse position
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
