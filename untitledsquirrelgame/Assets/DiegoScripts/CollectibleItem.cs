using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite collectedAcorn;
    private SpriteRenderer spriteRenderer;
    private bool isCollected = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCollected) return;

        if (collision.CompareTag("Player"))
        {
            isCollected = true;
            if (collectedAcorn != null)
            {
                spriteRenderer.sprite = collectedAcorn;
            }
            GetComponent<Collider2D>().enabled = false;
        }
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
}
