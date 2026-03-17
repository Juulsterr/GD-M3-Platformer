using JetBrains.Annotations;
using UnityEngine;

public class Heal : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D collision)
 {
  if (collision.gameObject.tag == "Player")
  {
   Player player = collision.gameObject.GetComponent<Player>();
   player.health = 100;
    Destroy(gameObject); // Destroy the coin after collecting it

  }
 }
  }

