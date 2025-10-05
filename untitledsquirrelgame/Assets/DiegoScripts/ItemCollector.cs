using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore;

public class ItemCollector : MonoBehaviour
{
    public int acornCheeks = 0;
    // public AudioClip collectSFX;

    public Sprite normalSprite;
    public Sprite threeAcornsSprite;
    public Sprite fiveAcornsSprite;

    // private AudioSource audioSoure;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        // Code to set starting sprite. Not sure if we'll need this but it's here anyway.
        if (normalSprite != null){
            spriteRenderer.sprite = normalSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Colliding with collectible acorns
        if (collision.CompareTag("Collectible"))
        {
            acornCheeks++;
            UpdatePlayerSprite();
        }

        // Code for colliding with deposit holes. WRITE LATER
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 
    }

    private void UpdatePlayerSprite()
    {
        if (acornCheeks >= 5 && fiveAcornsSprite != null)
        {
            spriteRenderer.sprite = fiveAcornsSprite;
        }
        else if (acornCheeks >= 3 && threeAcornsSprite != null)
        {
            spriteRenderer.sprite = threeAcornsSprite;
        }
        else if (normalSprite != null)
        {
            spriteRenderer.sprite = normalSprite;
        }
    }
}
