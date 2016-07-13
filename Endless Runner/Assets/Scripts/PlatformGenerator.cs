using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public ObjectPooler[] objectPools;
    private float[] platformWidths;
    private int platformSelector;

    public Transform generationPoint; 
    
    public float distMin, distMax;
    private float dist;

    private float minHeight, maxHeight;
    public Transform maxHeightPoint;

    public float maxHeightChange;
    private float heightChange;


	// Use this for initialization
	void Start () {
        platformWidths = new float[objectPools.Length];

        for (int i = 0; i < objectPools.Length; ++i)
        {
            platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < generationPoint.position.x)
        {
            dist = Random.Range(distMin, distMax);
            platformSelector = Random.Range(0, objectPools.Length);

            heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);

            heightChange = Mathf.Clamp(heightChange, minHeight, maxHeight);
            
            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector]/2f + dist, heightChange,transform.position.z);

            GameObject newPlatform = objectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] / 2f, transform.position.y, transform.position.z);
        }
	
	}
}
