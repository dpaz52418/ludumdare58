using Unity.VisualScripting;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.TextCore;

public class ItemCollector : MonoBehaviour
{
    public int acornCheeks = 0;
    // public AudioClip collectSFX;
    public float knockback = 3f;

    public Sprite normalSprite;
    public Sprite threeAcornsSprite;
    public Sprite fiveAcornsSprite;
    public Camera cameraAwesome;

    public CameraKill cameraKiller;

    // stuff for altering speed of movement.
    private Movement movementScript;

    private PlayerHealth ph;

    //private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        movementScript = GetComponent<Movement>();

        ph = GetComponent<PlayerHealth>();

        cameraAwesome = Camera.main;

        cameraKiller = cameraAwesome.GetComponent<CameraKill>();


        // Code to set starting sprite. Not sure if we'll need this but it's here anyway.
        if (normalSprite != null)
        {
            spriteRenderer.sprite = normalSprite;
        }

        // Stuff for audio
        // audioSource = GetComponent<AudioSource>(); ?? gameObject.AddComponent<AudioSource>().
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
            // Had a purpose. I moved its purpose to CollectibleItem. See collectibleitem's ontriggerenter.
            if (acornCheeks < 5)
            {
                // audioSource.PlayOneShot(collectSFX);
                //acornCheeks++;
                //UpdatePlayerSprite();
            }
        }

        // Code for colliding with enemies.
        if (collision.CompareTag("Enemy"))
        {
            if (acornCheeks > 0)
            {
                ph.TakeDamage(knockback);
            }
            else
            {
                cameraKiller.PlayerDeath(this.gameObject);
            }
        }
    }

    private void speedChanger()
    {
        // We've grabbed the movement script in the Start() function. We also
        // have access to the acornCheeks variable.

        movementScript.setSpeed(acornCheeks);
    }

    public void UpdatePlayerSprite()
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
        speedChanger();
    }
}
