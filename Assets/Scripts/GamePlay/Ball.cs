using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    public static float ballColliderRadius;

    Timer deathTimer;
    Timer moveTimer;

    CircleCollider2D circleCollider2D;

    Rigidbody2D rb2d;
    Timer speedupTimer;
    float speedupFactor;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        ballColliderRadius = circleCollider2D.radius;
        circleCollider2D.enabled = false;

        //deathTimer = gameObject.AddComponent<Timer>();
        //deathTimer.Duration = ConfigurationUtils.BallLifeSecond;
        //deathTimer.Run();

        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1f;
        moveTimer.Run();

        speedupTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedupEffectListener(CallSpeedupEffectActivatedEvent);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (deathTimer.Finished)
        //{
        //    Camera.main.GetComponent<BallSpawner>().spawnBall();
        //    Destroy(gameObject);
        //}

        if (moveTimer.Finished)
        {
            moveTimer.Stop();
            StartMoving();                      
        }

        if(speedupTimer.Finished)
        {
            speedupTimer.Stop();
            rb2d.velocity *= 1 / speedupFactor;
        }
    }

    public void StartMoving()
    {
        circleCollider2D.enabled = true;
        float angle = Mathf.Deg2Rad * 270;
        Vector2 move = new Vector2(ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle), ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        
        // adjust as necessary if speedup effect is active
        if (EffectUtils.SpeedupEffectActive)
        {
            this.speedupFactor = EffectUtils.SpeedupFactor;
            speedupTimer.Duration = EffectUtils.SpeedupEffectSecondsLeft;
            speedupTimer.Run();
            move *= speedupFactor;
        }

        GetComponent<Rigidbody2D>().AddForce(move);
    }

    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float velocity = rb2d.velocity.magnitude;
        rb2d.velocity = direction * velocity;
    }

    private void OnBecameInvisible()
    {
        //if(!deathTimer.Finished)
        //{
        //    float radius = gameObject.GetComponent<CircleCollider2D>().radius;
        //    if (transform.position.y - radius < ScreenUtils.ScreenBottom)
        //    {
        //        HUD.updateBallsLeftText();
        //        Camera.main.GetComponent<BallSpawner>().spawnBall();
        //    }
        //    Destroy(gameObject);
        //}
        float radius = gameObject.GetComponent<CircleCollider2D>().radius;
        if (transform.position.y - radius < ScreenUtils.ScreenBottom)
        {
            HUD.updateBallsLeftText();
            Camera.main.GetComponent<BallSpawner>().spawnBall();
        }
        Destroy(gameObject);
    }

    void CallSpeedupEffectActivatedEvent(float duration, float speedupFactor)
    {
        // speed up ball and run or add time to timer
        if (!speedupTimer.Running)
        {
            this.speedupFactor = speedupFactor;
            speedupTimer.Duration = duration;
            speedupTimer.Run();
            rb2d.velocity *= speedupFactor;
        }
        else
        {
            speedupTimer.addTime(duration);
        }
    }
}
