using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomVelocityFactor = 0.2f;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;



    // Start is called before the first frame update
    void Start()
    {
        // At game start, lock ball to paddle
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // if the game has not yet started, lock the ball to the paddle,
        // and invoke the method to launch the ball on mouse click
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }


    }

    // method to lock ball to paddle
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;

    }
    // method to launch the ball on mouse click
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xVelocity, yVelocity);

        }

    }

    // On a ball collision
    // change ball velocity
    // if the game has already started, play sound effects when ball hits collider
    // increase ball velocity at each hit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
        (Random.Range(0f, randomVelocityFactor),
        Random.Range(0f, randomVelocityFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
