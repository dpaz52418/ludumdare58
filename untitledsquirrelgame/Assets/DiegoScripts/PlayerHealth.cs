using NUnit.Framework;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ItemCollector ic;
    public int nutCount;
    public float stunDuration = 0.5f;
    private bool isStunned = false;
    private Camera mainCamera;
    public CameraKill cameraKiller;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    void Start()
    {
        ic = GetComponent<ItemCollector>();
        nutCount = ic.acornCheeks;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;
        cameraKiller = mainCamera.GetComponent<CameraKill>();

    }


    
    public void TakeDamage(float knockback)
    {
        if (isStunned) { return; }

        nutCount = ic.acornCheeks;
        if (nutCount != 0)
        {
            /*
            nutCount = 0;
            ic.acornCheeks = 0;
            rb.linearVelocityX = 0;
            rb.linearVelocityY = knockback;
            Debug.Log("pre awesome!!");
            StartCoroutine(StunCoroutine());
            Debug.Log("awesome!!!");
            */
         // A problem I couldn't quite solve is above. Come back one day, Diego! - Diego from 10/6/25
            cameraKiller.PlayerDeath(this.gameObject);

        }
        else
        {
            cameraKiller.PlayerDeath(this.gameObject);
        }
    }
    

    private System.Collections.IEnumerator StunCoroutine()
    {
        isStunned = true;

        sr.color = Color.red;

        yield return new WaitForSeconds(stunDuration);

        sr.color = Color.white;

        isStunned = false;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }


    public bool CanMove()
    {
        return !isStunned;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPos.x < 0 || viewportPos.x > 1 ||
            viewportPos.y < 0 || viewportPos.y > 1)
        {
            Die();
        }
    }
}
