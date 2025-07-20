
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;
public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI HighScoreTEXT;
    
    
    private void Start()
    {
        
        HighScoreTEXT.text = "HighScore: " + MainManager.Instance.HighScore;
        
        
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
}
