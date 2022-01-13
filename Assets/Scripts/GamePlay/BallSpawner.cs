using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall;

    Timer spawnTimer;

    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    bool retrySpawn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject tempBall = Instantiate<GameObject>(prefabBall);
        CircleCollider2D collider = tempBall.GetComponent<CircleCollider2D>();
        float ballColliderHalfWidth = collider.radius / 2;
        float ballColliderHalfHeight = collider.radius / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);

        spawnBall();

        //spawnTimer = gameObject.AddComponent<Timer>();
        //spawnTimer.Duration = getSpawnDuration();
        //spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        //if(spawnTimer.Finished)
        //{
        //    retrySpawn = false;
        //    spawnBall();
        //    spawnTimer.Duration = getSpawnDuration();
        //    //print(getSpawnDuration());
        //    spawnTimer.Run();
        //}


        //if (retrySpawn)
        //{
        //    spawnBall();
        //}
    }

    public void spawnBall()
    {
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            Instantiate<GameObject>(prefabBall);
            retrySpawn = false;
        }
        else
        {
            retrySpawn = true;
        }

    }

    private float getSpawnDuration()
    {
        return Random.Range(ConfigurationUtils.MinSpawnSecond, ConfigurationUtils.MaxSpawnSecond);
    }
}
