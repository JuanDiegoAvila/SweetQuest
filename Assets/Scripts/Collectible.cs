using UnityEngine;

public class Collectible : MonoBehaviour
{
    // You can add an optional score increment
    public int scoreValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Optional: Give the player points
            PlayerScore playerScore = collision.gameObject.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.AddScore(scoreValue);
            }

            // Destroy the collectible
            Destroy(gameObject);
        }
    }
}
