using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public GameObject background;
    public Camera selfCamera;

    private float x_offset;
    private Vector3 origPosition;

	void Start()
	{
        this.origPosition = this.transform.position;
        this.x_offset = this.transform.position.x - this.player.transform.position.x;// - this.background.transform.position.x;
	}
	
	void LateUpdate()
	{
        //Vector3 backgroundPosition = this.background.transform.position;
        float leftEdge = Mathf.Min(this.transform.position.x, (23 - (this.selfCamera.orthographicSize / 2)));
        //float rightEdge = Mathf.Max(this.background.transform.position.x, this.player.transform.position.x);
        float newX = leftEdge + this.x_offset;
        this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);
    }
}
