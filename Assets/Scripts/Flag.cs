using Unity.VisualScripting;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject WinUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0; // Pause the game when the player reaches the flag
            WinUI.SetActive(true); // Activate the win UI when the player reaches the flag
        }
    }
}
