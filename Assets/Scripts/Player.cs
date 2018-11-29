using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public string left, right, gravity;
    public float minGravity;
    public float maxGravity;
    private Rigidbody2D player;

    void Awake()
    {
        this.player = this.GetComponent<Rigidbody2D>();
    }

    void Start()
	{
        
    }
	
	void Update()
	{
		if (Input.GetKey(left))
        {
            this.player.AddForce(Vector2.left * 100 * Time.deltaTime);
        }

        if (Input.GetKey(right))
        {
            this.player.AddForce(Vector2.right * 100 * Time.deltaTime);
        }

        if (Input.GetKey(gravity))
        {
            this.player.gravityScale = this.minGravity;
        }
        else
        {
            this.player.gravityScale = this.maxGravity;
        }
    }
}
