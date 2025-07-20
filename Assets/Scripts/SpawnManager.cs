using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : AbstractBall
{
    //public AbstractBall AbstractBallScript = null;
    
    public int score;

    public GameObject greenBall;
    public GameObject redBall;
    
    
    private void Awake()
    {
        Health = 3;
        InvokeRepeating("SpawnBall", 1, 0.7f);
    }
    private void Update()
    {
        
    }
    public void SpawnBall()
    {
        int randomNum = Random.Range(0, 3);
        DestroyOutOfBound();
        switch (randomNum)
        {
            case 0:
                Instantiate(redBall, new Vector3(randomPosX(), 13, 0.5f), Quaternion.identity);
                return;
            case 1:
                Instantiate(greenBall, new Vector3(randomPosX(), 13, 0.5f), Quaternion.identity);
                return;
            case 2:
                Instantiate(greenBall, new Vector3(randomPosX(), 13, 0.5f), Quaternion.identity);
                return;

        }
        
        

    }
    public float randomPosX()
    {
        float posX = Random.Range(-4.5f, 4.6f);
        return posX;
    }
    public void DestroyOutOfBound()
    {
        GameObject[] greenBalls = GameObject.FindGameObjectsWithTag("Green");
        foreach (GameObject ball in greenBalls)
        {
            if (ball.transform.position.y < -10)
            {
                Destroy(ball);
            }
        }

        GameObject[] redBalls = GameObject.FindGameObjectsWithTag("Red");
        foreach (GameObject ball in redBalls)
        {
            if (ball.transform.position.y < -10)
            {
                Destroy(ball);
            }
        }
    }
    protected override void takeHP()
    {
          
    }
    protected override void increaseScore()
    {
        
    }
    
    // Start is called before the first frame update

}
