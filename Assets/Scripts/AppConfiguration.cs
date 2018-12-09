using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppConfiguration : MonoBehaviour {

    public static AppConfiguration Instance;

    public float scrollSpeed;                   // The speed the background will chase the player.
    public float playerRunningSpeed;            // How much faster the user will move from the scroll speed.
    public float backgroundChasingSpeed;        // Negative velocity from the moving direction of the camera - e.g the speed the user will go backwards when they don't press the key.
    public string userRunningKey;
    public float playerJumpForce;

    void Awake()
	{
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(gameObject); }
    }
	
	void Update()
	{
		
	}
}
