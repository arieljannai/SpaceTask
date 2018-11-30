using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject prefabsParent;
    public int NUMBER_OF_OBSTACLES;
    public int NUMBER_OF_BROKEN_PARTS;
    public float distanceFromTopEdge;
    public float distanceFromBottomEdge;
    public float distanceFromRightEdge;
    public float distanceFromLeftEdge;
    public GameObject borderTop;
    public GameObject borderBottom;
    public GameObject borderRight;
    public GameObject borderLeft;

    private float topObjectsLimit;
    private float bottomObjectsLimit;
    private float rightObjectsLimit;
    private float leftObjectsLimit;

    void Awake()
    {
        this.topObjectsLimit = this.borderTop.transform.position.y - this.distanceFromTopEdge;
        this.bottomObjectsLimit = this.borderBottom.transform.position.y + this.distanceFromBottomEdge;
        this.rightObjectsLimit = this.borderRight.transform.position.x - this.distanceFromRightEdge;
        this.leftObjectsLimit = this.borderLeft.transform.position.x + this.distanceFromLeftEdge;
    }

    void Start()
	{
        this.PutRandomResourcesOnScreen("Obstacle", NUMBER_OF_OBSTACLES);
        this.PutRandomResourcesOnScreen("BrokenShipPart", NUMBER_OF_BROKEN_PARTS);
    }
	
	void Update()
	{
        // 0 - Reset scene cheat
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            Debug.Log("Player: " + player);
            Debug.Log("Reloading scene with 0");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void PutRandomResourcesOnScreen(string resourceName, int nInstances)
    {
        for (int i = 0; i < nInstances; i++)
        {
            GameObject objResource = Instantiate(Resources.Load(resourceName)) as GameObject;

            float xPos = Random.Range(this.leftObjectsLimit, this.rightObjectsLimit);
            float yPos = Random.Range(this.bottomObjectsLimit, this.topObjectsLimit);

            // TODO: different sizes for the objects

            objResource.transform.position = new Vector3(xPos, yPos, 0);
            objResource.transform.parent = prefabsParent.transform;

            float randAngle = Random.Range(0, 200f);
            objResource.transform.eulerAngles = new Vector3(0, 0, randAngle);
        }
    }
}
