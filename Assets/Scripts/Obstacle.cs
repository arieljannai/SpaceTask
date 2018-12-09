using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	void Start()
	{
		
	}
	
	void Update()
	{
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision detected: " + this.name + " and " + collision.gameObject.name);
    }
}
