
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI HPtext;
    public TextMeshProUGUI scoretxt;
    
    public GameObject GameOverObj;
     
    public SpawnManager spawnManagerScript;

    

    private void Update()
    {
        HPtext.text = "HP: " + spawnManagerScript.Health;
        HighScoreText.text = "HighScore: " + MainManager.Instance.HighScore;
        scoretxt.text = "Score " + spawnManagerScript.score;
        if (spawnManagerScript.gameover)
        {
            GameOverObj.SetActive(true);
        }
        
    }
}
