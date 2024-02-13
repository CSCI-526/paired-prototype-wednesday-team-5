using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gameManager;
    public GameManager gameManagerScript;
    public GameObject floor;
    public Material currentFloorMaterial;
    public Material pastFloorMaterial;
    float horizontalMovement;
    float verticalMovement;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = new GameManager();
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        if (horizontalMovement > 0)
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalMovement);
        else
            Debug.Log("Cannot go back!");
        transform.Translate(Vector3.up * Time.deltaTime * verticalMovement * speed);
        
        TimeSwitch();
    }

    void TimeSwitch()
    {
        Debug.Log("The player value in bool is " + gameManagerScript.isCurrentTimeLine);

        if (gameManagerScript.isCurrentTimeLine)
        {
            Debug.Log("Inside true. ");
            floor.GetComponent<SpriteRenderer>().material = currentFloorMaterial;
            Camera.main.backgroundColor = Color.blue;
        }
        else
        {
            floor.GetComponent<SpriteRenderer>().material = pastFloorMaterial;
            Camera.main.backgroundColor = Color.grey;
        }

    }
    
}
