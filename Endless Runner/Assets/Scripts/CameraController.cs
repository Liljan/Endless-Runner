using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Transform player;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>().transform;
        lastPlayerPosition = player.position;
	}
	
	// Update is called once per frame
	void Update () {

        distanceToMove = player.position.x - lastPlayerPosition.x;
        this.transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = player.position;
	}
}
