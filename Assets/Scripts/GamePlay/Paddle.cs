using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    float halfWidthOfPaddle;
    float halfHeightOfPaddle;

    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    Timer freezeTimer;
    bool isFrozen = false;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
        halfWidthOfPaddle = bc2d.size.x / 2;
        halfHeightOfPaddle = bc2d.size.y / 2;

        freezeTimer = gameObject.AddComponent<Timer>();
        EventManager.AddFreezerEffectListener(CallFreezerEffectActivatedEvent);
    }

    // Update is called once per frame
    void Update()
    {
        if(freezeTimer.Finished)
        {
            isFrozen = false;
            freezeTimer.Stop();
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0 && !isFrozen)
        {
            Vector2 position = rb2d.position;
            position.x += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            position.x = calculateClampedX(position.x);
            rb2d.MovePosition(position);
        }
    }
    /// <summary>
    /// Paddle should be inside of the game view.
    ///
    /// </summary>
    /// <param name="positionX"></param>
    /// <returns></returns>
    private float calculateClampedX(float positionX)
    {   
        if(positionX + halfWidthOfPaddle > ScreenUtils.ScreenRight)
        {
            positionX = ScreenUtils.ScreenRight - halfWidthOfPaddle;
        }
        else if(positionX - halfWidthOfPaddle < ScreenUtils.ScreenLeft)
        {
            positionX = ScreenUtils.ScreenLeft + halfWidthOfPaddle;
        }
        return positionX;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && topCollision(coll))
        {
            // calculate new ball direction
            print("İcerdeyim");
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfWidthOfPaddle;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    /// <summary>
    /// Checks for a collision on the top of the paddle
    /// </summary>
    /// <returns><c>true</c>, if collision was on the top of the paddle, <c>false</c> otherwise.</returns>
    /// <param name="coll">collision info</param>
    bool topCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D[] contacts = coll.contacts;
        return Mathf.Abs((coll.transform.position.y - Ball.ballColliderRadius) - (transform.position.y + halfHeightOfPaddle)) <= tolerance;
    }

    void CallFreezerEffectActivatedEvent(float duration)
    {
        isFrozen = true;
        if(freezeTimer.Running)
        {
            freezeTimer.addTime(duration);
        }
        else
        {
            freezeTimer.Duration = duration;
            freezeTimer.Run();
        }
    }
}
