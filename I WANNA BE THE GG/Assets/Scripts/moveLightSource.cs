using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLightSource : MonoBehaviour {

    public Transform targetMarker;
    public float speed;

	
	// Update is called once per frame
	void Update () {
        if (transform.position != targetMarker.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetMarker.position, speed * Time.deltaTime);
        }
        
	}
}
