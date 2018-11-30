using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenShipPart : MonoBehaviour {

    public static Object[] brokenShipParts;

    void Awake()
    {
        if (brokenShipParts == null)
        {
            brokenShipParts = Resources.LoadAll("BrokenShipParts", typeof(Sprite));
        }
    }

    void Start()
	{
        int index = Random.Range(0, brokenShipParts.Length);
        this.GetComponent<SpriteRenderer>().sprite = Instantiate(brokenShipParts[index]) as Sprite;
    }
	
	void Update()
	{
		
	}
}
