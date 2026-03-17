using UnityEngine;

public class PreviousLevel : MonoBehaviour
{

    public string previousLevelName; // Name of the previous level to load
  public void LoadPreviousLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(previousLevelName);
        Time.timeScale = 1;
    } 
}
