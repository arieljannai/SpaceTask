using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public string left, right, up, gravity, running;
    public float minGravity;
    public float maxGravity;
    private Rigidbody2D player;
    private bool isRunning = false;
    private Vector2 defaultMovingDirection = Vector2.right;
    private float jumpForce;

    void Awake()
    {
        this.player = this.GetComponent<Rigidbody2D>();
        this.running = AppConfiguration.Instance.userRunningKey;
        this.jumpForce = AppConfiguration.Instance.playerJumpForce;
    }

    void Start()
	{
        
    }
	
	void Update()
	{
        // TODO: try to limit speed, think about the jumping and moving angles.
        // TODO: slow down when in air

        if (Input.GetKey(up))
        {
            this.player.AddForce((Vector2.up - (Vector2.down / 3)) * jumpForce * Time.deltaTime);
        }
        else if (Input.GetKeyUp(up))
        {
            this.player.AddForce((Vector2.down) * jumpForce * 3 * Time.deltaTime);
        }

        if (Input.GetKey(running))
        {
            this.isRunning = true;
            this.player.AddForce(new Vector2(AppConfiguration.Instance.playerRunningSpeed, 0) * Time.deltaTime);
        }
        else
        {
            this.isRunning = false;
            this.player.AddForce(new Vector2(AppConfiguration.Instance.backgroundChasingSpeed, 0) * Time.deltaTime);
        }
    }
}
