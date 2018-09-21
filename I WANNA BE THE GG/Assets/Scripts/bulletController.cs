using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

    public Vector2 speed;
    Rigidbody2D m_Rigidbody2D;

    // Use this for initialization
    void Start () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {
        m_Rigidbody2D.velocity = speed;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            //Debug.Log("COLLISION");
            Destroy(gameObject);
        }
    }
}
