using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{

    //Movement
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask backgroundLayer; // Only background tiles
    private bool isOnBackground; // If true, disable movement



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnBackground = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, backgroundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);    //Moving Right
            //Debug.Log("Case 1"); 
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);    //Moving Left
            //Debug.Log("Case 2"); 
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);    //Idle
            //Debug.Log("Case 3"); 
        }

        if (Input.GetButtonDown("Jump") && !isOnBackground)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            //Debug.Log("Case 4");
        }
    }
}
