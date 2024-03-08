using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public GameObject player;
    private PlayerControllerAdvanced playerControllerAdvanced;
    private PlayerScore playerScore;
    public Transform respownPoint;
    public GameObject[] checkPoints;
    public GameObject collectible;

    void Start()
    {
        playerControllerAdvanced = player.GetComponent<PlayerControllerAdvanced>();
        playerScore = player.GetComponent<PlayerScore>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !playerControllerAdvanced.aturdido)
        {
            playerControllerAdvanced.aturdido = true;
            StartCoroutine(RespawnPlayerAfterDelay());
        }
    }
    IEnumerator RespawnPlayerAfterDelay()
    {
        yield return new WaitForSeconds(0.8f);

        player.transform.position = respownPoint.position;
        playerControllerAdvanced.aturdido = false;
        //CheckAndSpawnCollectibles();
    }

    //void CheckAndSpawnCollectibles()
    //{
    //    foreach (GameObject checkpoint in checkPoints)
    //    {
    //        Checkpoint checkpointScript = checkpoint.GetComponent<Checkpoint>();
    //        if (checkpointScript == null || checkpointScript.hasCollectible) continue;

    //        playerScore.RemoveScore(1);

    //        Vector3 spawnPosition = checkpoint.transform.position;

    //        BoxCollider2D boxCollider = checkpoint.GetComponent<BoxCollider2D>();
    //        if (boxCollider != null)
    //        {
    //            spawnPosition.y += boxCollider.size.y * 0.5f * checkpoint.transform.localScale.y;
    //        }

    //        Instantiate(collectible, spawnPosition, Quaternion.identity);
    //    }
    //}

}
