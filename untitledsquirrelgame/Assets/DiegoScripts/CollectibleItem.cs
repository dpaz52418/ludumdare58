using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite originalSprite, oneSprite, twoSprite, threeSprite;
    public Sprite collectedAcorn;
    private SpriteRenderer spriteRenderer;
    public int acornsLeft = 0;
    private bool fullyCollected = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        acornsLeft = whichAcornSprite();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (fullyCollected) return;

        if (collision.CompareTag("Player"))
        {
            // We want to be able to check the amount of nuts in their mouth.
            ItemCollector collectorScript = collision.GetComponent<ItemCollector>();

            // We then want to check that their mouth is not full.
            int newTotal = (collectorScript.acornCheeks + acornsLeft);
            if (collectorScript.acornCheeks >= 5)
            {
                return;
            }
            if (newTotal < 6) // If newTotal is below 6.
            {
                fullyCollected = true;
                if (collectedAcorn != null)
                {
                    // Before changing the sprite to an empty branch, add the score.
                    collectorScript.acornCheeks += acornsLeft;
                    acornsLeft = 0;

                    // Change the sprite to an empty branch.
                    spriteRenderer.sprite = collectedAcorn;

                    // Update the sprite of the player if necessary.
                    collectorScript.UpdatePlayerSprite();
                }
                GetComponent<Collider2D>().enabled = false;
            }
            else // If new total is above 5, partial collection.
            {
                int remainder = (newTotal - 5);
                if (remainder == 2)
                {
                    spriteRenderer.sprite = twoSprite;
                    collectorScript.acornCheeks = 5;
                    acornsLeft = 2;

                }
                else if (remainder == 1)
                {
                    spriteRenderer.sprite = oneSprite;
                    collectorScript.acornCheeks = 5;
                    acornsLeft = 1;

                }
                
                // Update the sprite of the player if necessary.
                collectorScript.UpdatePlayerSprite();

            }
        }
    }

    private int whichAcornSprite()
    {
        /*
        NOTE: For now, here are the names for the relevant acorn branch sprites.
        0 acorn branch: tree_4
        1 Acorn branch: tree_5
        2 acorn branch: tree_6
        3 acorn branch: tree_7
        */
        string awesome = spriteRenderer.sprite.name;
        if (awesome == "tree_7")
        {
            return 3;
        }
        else if (awesome == "tree_6")
        {
            return 2;
        }
        else if (awesome == "tree_5")
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
}
