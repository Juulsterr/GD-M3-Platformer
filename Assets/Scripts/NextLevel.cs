using UnityEngine;

public class NextLevel : MonoBehaviour
{

    public string nextLevelName; // Name of the next level to load
  public void LoadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevelName);
        Time.timeScale = 1;
    } 
}
