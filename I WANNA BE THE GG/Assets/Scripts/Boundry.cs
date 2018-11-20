using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //Debug.Log("Collision");
            Destroy(other.gameObject);
        }
    }
}
