using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject player;
    public int NUMBER_OF_OBSTACLES;
    public int NUMBER_OF_BROKEN_PARTS;
    
	void Start()
	{
        // TODO: check why it's throwing an error
        //this.PutRandomResourcesOnScreen("meteor", NUMBER_OF_OBSTACLES);
        //this.PutRandomResourcesOnScreen("collect-1", NUMBER_OF_BROKEN_PARTS);
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

            float xPos = Random.Range(-19f, 19f);
            float yPos = Random.Range(-8f, 11f);

            objResource.transform.position = new Vector3(xPos, yPos, 0);

            float randAngle = Random.Range(0, 200f);
            objResource.transform.eulerAngles = new Vector3(0, 0, randAngle);
        }
    }
}
