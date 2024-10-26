using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerVelocity;
    private Vector3 playerPosition;
    [SerializeField] private float boundary; 

    public Rigidbody2D rigibody2D;
    Vector2 startPosition;

    void Start()
    {

       
        playerPosition = gameObject.transform.position;

        startPosition = transform.position;
    }

    void Update()
    {
      
        float mouseX = Input.mousePosition.x;
       
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, 0, Camera.main.nearClipPlane));
       
        playerPosition.x = mouseWorldPosition.x;

        if (playerPosition.x < -boundary)
        {
            playerPosition.x = -boundary;
        }
        if (playerPosition.x > boundary)
        {
            playerPosition.x = boundary;
        }

        transform.position = new Vector3(playerPosition.x, transform.position.y, transform.position.z);

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
