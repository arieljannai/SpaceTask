using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    
    public float leftmostX;
    public float rightmostX;
    
	void LateUpdate()
	{
        Vector3 newPosition = this.transform.position;
        newPosition.x = Mathf.Max(this.leftmostX, Mathf.Min(this.rightmostX, this.player.transform.position.x));
        this.transform.position = newPosition;
    }
}
