using UnityEngine;
using UnityEngine.TextCore;

public class ItemCollector : MonoBehaviour
{

    /*    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    public static int acornCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            acornCount++;
            //Destroy(collision.gameObject);

            // try to get collectibleitem script from collectible
            CollectibleItem collectible = collision.GetComponent<CollectibleItem>();
            {

            }

        }
    }
}
