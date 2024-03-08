using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool hasCollectible = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            hasCollectible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            Debug.Log("Tiene collectible");
            hasCollectible = false;
        }
    }
}
