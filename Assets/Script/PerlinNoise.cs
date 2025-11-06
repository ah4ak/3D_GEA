using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PerlinNoise Value: " + Mathf.PerlinNoise(.5f, .1f));
        Debug.Log("PerlinNoise Value: " + Mathf.PerlinNoise(.5f, .2f));
        Debug.Log("PerlinNoise Value: " + Mathf.PerlinNoise(.5f, .3f));
        Debug.Log("PerlinNoise Value: " + Mathf.PerlinNoise(.5f, .4f));
        Debug.Log("PerlinNoise Value: " + Mathf.PerlinNoise(.5f, .5f));
    }
}
