using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public GameObject background;
    public Camera selfCamera;

    private float x_offset;
    private float leftmost;
    private Vector3 origPosition;

	void Start()
	{
        this.leftmost = this.transform.position.x;
        this.origPosition = this.transform.position;
        this.x_offset = this.leftmost - this.player.transform.position.x;// - this.background.transform.position.x;
	}
	
	void LateUpdate()
	{
        float leftEdge = Mathf.Min(this.leftmost, this.player.transform.position.x);
        float rightEdge = Mathf.Max(this.background.transform.position.x, this.player.transform.position.x);
        float newX = leftEdge + this.x_offset;
        this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);
    }
}
