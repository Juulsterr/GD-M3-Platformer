using Unity.VisualScripting;
using UnityEngine;

public class EndFlag : MonoBehaviour
{
    public GameObject EndUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0; // Pause the game when the player reaches the flag
            EndUI.SetActive(true); // Activate the end UI when the player reaches the flag
        }
    }
}
