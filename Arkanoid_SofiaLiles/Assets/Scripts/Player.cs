using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerVelocity;
    private Vector3 playerPosition;
    [SerializeField] private float boundary; // Use SerializeField for private access
    private int playerLives;
    private int playerPoints;

    // Use this for initialization 
    void Start()
    {
        // Get the initial position of the game object 
        playerPosition = gameObject.transform.position;
        playerLives = 3;
        playerPoints = 0;
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

    // Method to add points
    public void AddPoints(int points)
    {
        playerPoints += points;
        Debug.Log("Player Points: " + playerPoints);
    }

    // Optional: Method to reset player position
    public void ResetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
    void OnGUI()
    {
        GUI.Label(new Rect(5.0f, 3.0f, 200.0f, 200.0f), "Live's: " + playerLives + " Score: " + playerPoints);

    }
}
