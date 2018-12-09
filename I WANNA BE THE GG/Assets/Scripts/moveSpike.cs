using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSpike : MonoBehaviour {

    public Transform targetMarker;
    public float speed;
    bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggered = true;
        }
    }

    void Update ()
    {
        if(triggered && transform.position != targetMarker.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetMarker.position, speed * Time.deltaTime);
        }
    }
}
