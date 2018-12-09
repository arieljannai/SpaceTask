using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandomizer : MonoBehaviour {

    public static BackgroundRandomizer Instance;

    private List<GameObject> backgrounds;
    public GameObject currentBackground;
    private float lastIndex = 0;
    private float prevLastIndex = 1;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(gameObject); }
        Debug.Log(currentBackground);
        this.backgrounds = new List<GameObject>();
        this.backgrounds.AddRange(GameObject.FindGameObjectsWithTag("Background"));
        this.ShuffleBackgrounds();
    }

    public List<GameObject> Backgrounds
    {
        get { return this.backgrounds; }
    }
    
    public GameObject GetBackground()
    {
        //return this.backgrounds[Random.Range(0, this.backgrounds.Count)];
        return this.GetBackground(this.currentBackground);
    }

    public GameObject GetBackground(GameObject excludeBackground)
    {
        int randomIndex = Random.Range(0, this.backgrounds.Count);

        while (randomIndex == lastIndex || randomIndex == prevLastIndex)
        {
            randomIndex = Random.Range(0, this.backgrounds.Count);
        }

        this.prevLastIndex = lastIndex;
        this.lastIndex = randomIndex;

        //float excludeIndex = this.backgrounds.FindIndex(x => excludeBackground);
        //int randomIndex = Random.Range(0, this.backgrounds.Count - 1);
        //randomIndex = randomIndex == excludeIndex ? randomIndex + 1 : randomIndex;
        return this.backgrounds[randomIndex];
        //return go;
    }

    public void ShuffleBackgrounds()
    {
        this.backgrounds.Shuffle();
    }
}

public static class IListExtensions
{
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}