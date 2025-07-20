
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : AbstractBall // INHERITANCE
{
    //public AbstractBall AbstractBallScript = null;
    
    public int score;

    public GameObject greenBall;
    public GameObject redBall;

    
    public bool gameover;
    private void Awake()
    {
        Health = 3;
        InvokeRepeating("SpawnBall", 1, 0.7f);
        MainManager.Instance.LoadData();
    }
    private void Update()
    {
        
        if (Health <= 0)
        {
            gameover = true;
        }
        Debug.Log(score);
        
    }
    public void SpawnBall()
    {
        
        if (!gameover)
        {
            int randomNum = Random.Range(0, 3);
            DestroyOutOfBound();
            increaseScore();
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
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    protected override void takeHP()
    {
          
    }
    protected override void increaseScore()
    {
        if(score > MainManager.Instance.HighScore)
        {
            
            MainManager.Instance.HighScore = score;
            MainManager.Instance.SaveData();
        }
    }
    
    // Start is called before the first frame update

}
