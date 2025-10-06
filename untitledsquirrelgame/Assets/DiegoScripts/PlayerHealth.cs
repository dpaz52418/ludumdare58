using NUnit.Framework;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ItemCollector ic;
    public int nutCount;
    public float stunDuration = 0.5f;
    private bool isStunned = false;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    void Start()
    {
        ic = GetComponent<ItemCollector>();
        nutCount = ic.acornCheeks;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(float knockback)
    {
        if (isStunned) { return; }

        nutCount = ic.acornCheeks;
        if (nutCount != 0)
        {
            nutCount = 0;
            rb.linearVelocityX = 0;
            rb.linearVelocityY = knockback;

            StartCoroutine(StunCoroutine());


        }
        else
        {
            Die();
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

    private void Die()
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
        
    }
}
