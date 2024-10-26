using UnityEngine;

public class Blocks : MonoBehaviour
{
    public int hitsToKill = 1; // Number of hits required to destroy the block
    public int points; // Points awarded for destroying the block
    private int numberOfHits; // Counter for hits

    void Start()
    {
        numberOfHits = 0; // Initialize hits
    }

    void Update()
    {
        // No update logic needed unless you're adding functionality
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            numberOfHits++;
            if (numberOfHits == hitsToKill)
            {
                // destroy the object 
                Destroy(this.gameObject);
            }
        }
    }
}
