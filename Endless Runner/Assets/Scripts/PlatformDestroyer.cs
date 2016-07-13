using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

    private Transform destroyPoint;

	// Use this for initialization
	void Start () {
        destroyPoint = GameObject.FindGameObjectWithTag("DestroyPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < destroyPoint.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
	}
}
