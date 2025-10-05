using UnityEngine;

public class DepositHole : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // I don't think I need to start with anything.
    }

    // Update is called once per frame
    void Update()
    {
        // I don't think I need to update anything. It's a fixed hole.
    }

    // For simplicity, we can implement it such that when the player simply collides with the hole,
    // if there are any nuts in its mouth, they just become deposited in the score.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Get the collector script on the player so we can access public variables, i.e. acorncheeks.
            ItemCollector collectorScript = collision.GetComponent<ItemCollector>();

            // Grab the score from the squirrel
            int temp = collectorScript.acornCheeks;
            collectorScript.acornCheeks = 0;

            // update the squirrel's sprite
            collectorScript.UpdatePlayerSprite();

            // and add it to the global score
            ScoreManager.Instance.addScore(temp);


        }
    }
}