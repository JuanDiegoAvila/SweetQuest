using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int currentScore = 0;
    public static int collectibleCount;
    public GameObject endCanvas;

    // Optional: If you have a UI element to display the score
    public TMPro.TextMeshProUGUI scoreText; // Assign in the Inspector

    public void Start()
    {
        collectibleCount = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;

        // Update the UI if you have one
        if (scoreText != null)
        {
            scoreText.text = "x " + currentScore;
        }
        collectibleCount--;


        if (collectibleCount <= 0)
        {
            AllCollectiblesCollected();
        }
    }

    public void RemoveScore(int scoreToRemove)
    {
        currentScore -= scoreToRemove;
        if (scoreText != null)
        {
            scoreText.text = "x " + currentScore;
        }


        collectibleCount++;
    }

    void AllCollectiblesCollected()
    {
        endCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
