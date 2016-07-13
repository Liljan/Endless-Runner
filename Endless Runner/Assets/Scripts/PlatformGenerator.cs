using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public GameObject PlatformPrefab;
    public Transform generationPoint; 
    
    public float distMin, distMax;
    private float dist;

    private float platformWidth;

    private ObjectPooler objectPool;

	// Use this for initialization
	void Start () {
        platformWidth = PlatformPrefab.GetComponent<BoxCollider2D>().size.x;
        objectPool = GameObject.FindObjectOfType<ObjectPooler>();
	}
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.x < generationPoint.position.x)
        {
            dist = Mathf.Clamp(Random.value*distMax,distMin,distMax);
            this.transform.position = new Vector3(transform.position.x + platformWidth + dist, transform.position.y, transform.position.z);
            GameObject newPlatform = objectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            // Instantiate(PlatformPrefab,transform.position, transform.rotation);
        }
	
	}
}
