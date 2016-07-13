using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject[] platformPrefab;
    private float[] platformWidth;
    private int currentPlatform;

    // spawning
    public Transform generationPoint;
    public float minDist,maxDist;
    private float dist;

    // Use this for initialization
    void Start()
    {
        platformWidth = new float[platformPrefab.Length];

        for (int i = 0; i < platformPrefab.Length; ++i)
            platformWidth[i] = platformPrefab[i].GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < generationPoint.position.x)
        {
            GenerateRandomPlatform();
        }
    }

    private void GenerateRandomPlatform()
    {
        dist = Random.Range(minDist, maxDist);
        currentPlatform = Random.Range(0, platformPrefab.Length);
       
        Instantiate(platformPrefab[currentPlatform], new Vector3(transform.position.x + platformWidth[currentPlatform] / 2f + dist, transform.position.y, transform.position.z), transform.rotation);
        this.transform.position = new Vector3(transform.position.x + platformWidth[currentPlatform] + dist, transform.position.y,transform.position.z);
        Debug.Log(this.transform.position.x);
    }
}
