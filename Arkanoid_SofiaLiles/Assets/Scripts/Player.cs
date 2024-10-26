using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerVelocity;
    private Vector3 playerPosition;
    [SerializeField] private float boundary; // Use SerializeField for private access

    public Rigidbody2D rigibody2D;
    Vector2 startPosition;

    // Use this for initialization 
    void Start()
    {

        // Get the initial position of the game object 
        playerPosition = gameObject.transform.position;

        startPosition = transform.position;
    }

    // Update is called once per frame 
    void Update()
    {
        // Move with mouse
        float mouseX = Input.mousePosition.x;
        // Convert mouse position to world position
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, 0, Camera.main.nearClipPlane));
       
        // Update player position based on mouse position
        playerPosition.x = mouseWorldPosition.x;

        // Apply boundaries
        if (playerPosition.x < -boundary)
        {
            playerPosition.x = -boundary;
        }
        if (playerPosition.x > boundary)
        {
            playerPosition.x = boundary;
        }

        // Update the game object transform 
        transform.position = new Vector3(playerPosition.x, transform.position.y, transform.position.z);

        // Leave the game 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void ResetPlayer()
    {
        transform.position = startPosition;
        Vector2 zero = Vector2.zero;
        rigibody2D.velocity = zero;
    }

}
