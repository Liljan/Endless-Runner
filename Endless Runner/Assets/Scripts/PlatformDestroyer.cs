using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {
    private Transform destroyPoint;
    private float halfWidth;

	void Start () {
        destroyPoint = GameObject.FindGameObjectWithTag("DestroyPoint").transform;
        halfWidth = GetComponent<BoxCollider2D>().bounds.size.x /2f;
	}
	
	void Update () {
        if (transform.position.x + halfWidth < destroyPoint.position.x)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
	}
}
