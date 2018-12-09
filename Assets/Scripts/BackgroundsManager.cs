using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundsManager : MonoBehaviour {

    public static BackgroundsManager Instance;
    private float groundHorizontalLength;
    private Vector2 groundOffSet;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(gameObject); }

        //groundHorizontalLength = BackgroundRandomizer.Instance.backgrounds[0].GetComponent<BoxCollider2D>().size.x;
        groundHorizontalLength = GameObject.FindGameObjectWithTag("Background").GetComponent<BoxCollider2D>().size.x;
        groundOffSet = new Vector2(groundHorizontalLength, 0);
    }

    void Start()
    {
        int idx = 0;

        // Locate each background
        foreach (GameObject bg in BackgroundRandomizer.Instance.Backgrounds)
        {
            bg.transform.position = (Vector2) bg.transform.position + groundOffSet * idx;
            idx++;
        }
    }

    //public void PutNextBackground(GameObject currBackground)
    //{
    //    GameObject nextBackground = BackgroundRandomizer.Instance.GetBackground();
    //    //GameObject nextBackground2 = BackgroundRandomizer.Instance.GetBackground();
        
    //    currBackground.transform.position = (Vector2) currBackground.transform.position + (groundOffSet * (BackgroundRandomizer.Instance.Backgrounds.Count - 1));
    //    nextBackground.transform.position = (Vector2) nextBackground.transform.position + groundOffSet;
    //    //nextBackground2.transform.position = (Vector2) nextBackground2.transform.position + groundOffSet * 2;
    //    BackgroundRandomizer.Instance.currentBackground = nextBackground;
    //}
}
